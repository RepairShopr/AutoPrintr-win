# AutoPrintr

Allow to automatically print PDF files from http://www.repairshopr.com/

## Configuration

AutoPrintr stores it's configuration in 

```
    <home_directory>/config.json
```

After first run AutoPrintr will automatically create this file.

Configuration example:

```
{
  "location": [					// List of locations ID or one location
    1019
  ],
  "printers": [					// Printers configuration
    {
      "name": "File Printer",		// Printer system name
      "types": [					// ID of documents types for this printer
      	1,
      	3,
      	7
      ]				
    },
    {
      "name": "Microsoft XPS Document Writer",
      "types": [
        9
      ]
    }
  ]
}
```
