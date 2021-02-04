// modified from: https://gist.github.com/crubier/3cfcd4931f9c52d93fed4c18d2edee16

const fs = require('fs');
const path = require('path');
const util = require('util');

const readdir = util.promisify(fs.readdir);

// todo: fix this damn file
async function getFiles(dirname = './', options = {}) {
  const ignore = options.ignore || [];
  if (!options.basePath) {
    options.basePath = dirname;
  }
  const entries = await readdir(dirname, { withFileTypes: true });

  // Get files within the current directory and add a path key to the file objects
  const files = entries
      .filter(file => {
        if (file.isDirectory()) {
          return false;
        }
        const relPath = path.relative(options.basePath, path.resolve(dirname, file.name));
        return options.match ? options.match.test(relPath) : true;
      })
      .map(file => ({
        ...file,
        absolutePath: path.resolve(dirname, file.name),
        relativePath: path.relative(options.basePath, path.resolve(dirname, file.name))
      }));

  // Get folders within the current directory
  const folders = entries.filter(folder => folder.isDirectory());

  for (const folder of folders) {
      /*
        Add the found files within the subdirectory to the files array by calling the
        current function itself
      */
    if (!ignore.includes(folder.name)) {
      files.push(...await getFiles(path.resolve(dirname, folder.name), options));
    }
  }

  return files;
}

async function readFiles(dirname, options, onFileContent, onError) {
  const files = await getFiles(dirname, options);
  console.log('files', files);
  files.slice(0, 2).forEach(file => {
    // const { name, absolutePath, relativePath } = file;
    fs.readFile(absolutePath, 'utf-8', function(err, content) {
      if (err) {
        onError(err);
        return;
      }
      onFileContent(file, content);
    });
  });
}

function replaceRecursive(dirname, options, getContent, onSuccess) {
  readFiles(dirname,
    options,
    function(file, content) {
      const newcontent = getContent(content, file.relativePath);
      // console.log('newcontent', newcontent);
      fs.writeFile(file.absolutePath, newcontent, { encoding: 'utf8' }, (err) => {
        if (err) {
          throw err;
        } else if(onSuccess) {
          onSuccess();
        }
      });
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