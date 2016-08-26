# AutoPrintr

Allow to automatically print PDF files from http://www.repairshopr.com/

## Configuration

Programm store global configuration in 

```
    <home_directory>/config.json
```

After first run programm will automatically create this file.

Configuration example:

```
{
  "serverKey": "abcde-12345", 	// Jobs server API key (manual input)
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
