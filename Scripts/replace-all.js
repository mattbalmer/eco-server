const path = require('path');
const fs = require('fs');
const { replaceRecursive } = require('./utils/replace-recursive');

replaceRecursive(path.resolve(__dirname, '..', 'Mods'),
  {
    ignore: [
      '.git',
      'Scripts',
      'WebClient',
    ]
  },
  (content, filename) => {
    console.log(`Replacing ${filename}`);
    return content
      .replace(/\[MaxStackSize\(20\)\]/g, "[MaxStackSize(40)]")
      .replace(/\[MaxStackSize\(15\)\]/g, "[MaxStackSize(60)]")
      .replace(/\[MaxStackSize\(10\)\]/g, "[MaxStackSize(40)]")

      .replace(/MaturityAgeDays = 0.8f/g, "MaturityAgeDays = 0.65f")
      .replace(/MaturityAgeDays = 1f/g, "MaturityAgeDays = 0.8f")
      .replace(/MaturityAgeDays = 4.5f;/g, "MaturityAgeDays = 2.5f;")
      .replace(/MaturityAgeDays = 5;/g, "MaturityAgeDays = 3;")
      .replace(/MaturityAgeDays = 5.5f/g, "MaturityAgeDays = 3.5")
      .replace(/MaturityAgeDays = 6/g, "MaturityAgeDays = 4f")
      .replace(/MaturityAgeDays = 7/g, "MaturityAgeDays = 4.5f")
      .replace(/MaturityAgeDays = 30/g, "MaturityAgeDays = 10")
    ;
  }
);

/*
Manual Changes:
- [MaxStackSize(20)]
- 
*/ 