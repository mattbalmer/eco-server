const path = require('path');
const fs = require('fs');
const { replaceRecursive } = require('./utils/replace-recursive');

const options = {
  signHeader: true,
  ignoreSigned: true,
};

const HEADER = '// This file modified by @mbalmer eco-custom-server script';

replaceRecursive(path.resolve(__dirname, '..', 'Mods/AutoGen/Plant'),
  {
    match: /.*\.cs$/g,
    ignore: [
      '.git',
      'Scripts',
      'WebClient',
    ]
  },
  (rawContent, file) => {
    const filepath = file.relativePath;
    const filename = file.name;
    let content = (' ' + rawContent).slice(1);

    if (options.ignoreSigned && content.includes(HEADER)) {
      console.log('Skipping file ', filepath);
      return;
    }

    if (filename === 'TinyStockpileObject.cs') {
      content = content
        .replace(`new StockpileStackRestriction(DefaultDim.y)`, 'new StockpileStackRestriction(DefaultDim.y * 5)')
        .replace(`storage.Initialize`, 'this.GetComponent<LinkComponent>().Initialize(15);\n            storage.Initialize')
      ;
    }

    if (filename === 'SmallStockpileObject.cs') {
      content = content
        .replace(`new StockpileStackRestriction(DefaultDim.y)`, 'new StockpileStackRestriction(DefaultDim.y * 8)')
        .replace(`storage.Initialize`, 'this.GetComponent<LinkComponent>().Initialize(15);\n            storage.Initialize')
    }

    if (filename === 'StockpileObject.cs') {
      content = content
        .replace(`new StockpileStackRestriction(DefaultDim.y)`, 'new StockpileStackRestriction(DefaultDim.y * 10)')
        .replace(`storage.Initialize`, 'this.GetComponent<LinkComponent>().Initialize(15);\n            storage.Initialize')
    }

    if (filename === 'LumberStockpileObject.cs') {
      content = content
        .replace(`new StockpileStackRestriction(DefaultDim.y)`, 'new StockpileStackRestriction(DefaultDim.y * 12)')
        .replace(`storage.Initialize`, 'this.GetComponent<LinkComponent>().Initialize(15);\n            storage.Initialize')
    }

    if (filename === 'LargeLumberStockpileObject.cs') {
      content = content
        .replace(`new StockpileStackRestriction(DefaultDim.y)`, 'new StockpileStackRestriction(DefaultDim.y * 12)')
        .replace(`storage.Initialize`, 'this.GetComponent<LinkComponent>().Initialize(15);\n            storage.Initialize')
    }

    if (filename === 'StorageChestObject.cs') {
      content = content
        .replace(`this.GetComponent<LinkComponent>().Initialize(5);`, 'this.GetComponent<LinkComponent>().Initialize(10);')
    }

    if (filename === 'StorageChestObject.cs') {
      content = content
        .replace(`this.GetComponent<LinkComponent>().Initialize(5);`, 'this.GetComponent<LinkComponent>().Initialize(10);')
    }

    if (filename === 'SiloObjects.cs') {
      content = content
        .replace(
          /this\.GetComponent<PublicStorageComponent>/g,
          'this.GetComponent<LinkComponent>().Initialize(20);\n            this.GetComponent<PublicStorageComponent>'
        )
    }

    if (filename === 'SteamTruck.cs') {
      content = content
        .replace(
          `this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,2,3))`,
          'this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2,6,3))'
        )
    }

    content = content
      .replace(/\[MaxStackSize\(20\)\]/g, "[MaxStackSize(40)]")
      .replace(/\[MaxStackSize\(15\)\]/g, "[MaxStackSize(60)]")
      .replace(/\[MaxStackSize\(10\)\]/g, "[MaxStackSize(40)]")

      .replace(/MaturityAgeDays = 0.8f/g, "MaturityAgeDays = 0.65f")
      .replace(/MaturityAgeDays = 1f/g, "MaturityAgeDays = 0.8f")
      .replace(/MaturityAgeDays = 4.5f/g, "MaturityAgeDays = 2.5f")
      .replace(/MaturityAgeDays = 5;/g, "MaturityAgeDays = 3f;")
      .replace(/MaturityAgeDays = 5.5f/g, "MaturityAgeDays = 3.5f")
      .replace(/MaturityAgeDays = 6;/g, "MaturityAgeDays = 4f;")
      .replace(/MaturityAgeDays = 7;/g, "MaturityAgeDays = 4.5f;")
      .replace(/MaturityAgeDays = 30;/g, "MaturityAgeDays = 10f;")
    ;

    if (content !== rawContent) {
      if (options.signHeader) {
        const lines = content.split('\n');
        lines.splice(2, 0, HEADER);
        content = lines.join('\n');
      }
      console.log('Modified file ', filepath);
    } else {
      console.log('Read file     ', filepath);
    }

    return content;
  }
);

/*
Manual Changes:
- [MaxStackSize(20)]
- 
*/ 