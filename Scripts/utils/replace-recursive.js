// modified from: https://gist.github.com/crubier/3cfcd4931f9c52d93fed4c18d2edee16

const fs = require('fs');
const path = require("path");

// todo: fix this damn file
async function getFiles(path = "./") {
  const entries = await fs.readdir(path, { withFileTypes: true });

  // Get files within the current directory and add a path key to the file objects
  const files = entries
      .filter(file => !file.isDirectory())
      .map(file => ({ ...file, path: path + file.name }));

  // Get folders within the current directory
  const folders = entries.filter(folder => folder.isDirectory());

  for (const folder of folders)
      /*
        Add the found files within the subdirectory to the files array by calling the
        current function itself
      */
      files.push(...await getFiles(`${path}${folder.name}/`));

  return files;
}

async function readFiles(dirname, onFileContent, onError) {
  const files = await getFiles(dirname);
  fs.readdir(dirname, function(err, filenames) {
    if (err) {
      onError(err);
      return;
    }
    filenames.forEach(function(filename) {
      fs.readFile(dirname + filename, 'utf-8', function(err, content) {
        if (err) {
          onError(err);
          return;
        }
        onFileContent(filename, content);
      });
    });
  });
}

function replaceRecursive(dirname, getContent) {
  readFiles('./',
    function(filename, content) {
      const newcontent = getContent(content, filename);
      fs.writeFile(filename, newcontent, { encoding: 'utf8' });
    },
    function(err) {
      throw err;
    }
  );
}

module.exports = {
  readFiles,
  replaceRecursive,
};

readFiles('./',
  function(filename, content) {
    console.log(filename);
    // var newcontent=content.replace(/\n"\nauthor/,"\nauthor");
    const newcontent = content.replace(/title:\s*"([^"]*)\nauthor/,"title: \"$1\"\nauthor");
    fs.writeFile(filename, newcontent, { encoding: 'utf8' }, function() {
        console.log('OK '+filename);
    });
  },
  function(err) {
    throw err;
  }
);