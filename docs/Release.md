<a name='contents'></a>
# Contents [#](#contents 'Go To Here')

- [addJobControlsCb](#T-AutoPrintr-JobsList-addJobControlsCb 'AutoPrintr.JobsList.addJobControlsCb')
- [CheckBoxList](#T-AutoPrintr-CheckBoxList 'AutoPrintr.CheckBoxList')
  - [components](#F-AutoPrintr-CheckBoxList-components 'AutoPrintr.CheckBoxList.components')
  - [Dispose(disposing)](#M-AutoPrintr-CheckBoxList-Dispose-System-Boolean- 'AutoPrintr.CheckBoxList.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-AutoPrintr-CheckBoxList-InitializeComponent 'AutoPrintr.CheckBoxList.InitializeComponent')
- [CheckBoxListItem](#T-AutoPrintr-CheckBoxListItem 'AutoPrintr.CheckBoxListItem')
- [CheckBoxSlider](#T-AutoPrintr-CheckBoxSlider 'AutoPrintr.CheckBoxSlider')
  - [_checked](#F-AutoPrintr-CheckBoxSlider-_checked 'AutoPrintr.CheckBoxSlider._checked')
  - [Changed](#F-AutoPrintr-CheckBoxSlider-Changed 'AutoPrintr.CheckBoxSlider.Changed')
  - [Click](#F-AutoPrintr-CheckBoxSlider-Click 'AutoPrintr.CheckBoxSlider.Click')
  - [components](#F-AutoPrintr-CheckBoxSlider-components 'AutoPrintr.CheckBoxSlider.components')
  - [Dispose(disposing)](#M-AutoPrintr-CheckBoxSlider-Dispose-System-Boolean- 'AutoPrintr.CheckBoxSlider.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-AutoPrintr-CheckBoxSlider-InitializeComponent 'AutoPrintr.CheckBoxSlider.InitializeComponent')
  - [SetToolTip(tt,text)](#M-AutoPrintr-CheckBoxSlider-SetToolTip-System-Windows-Forms-ToolTip,System-String- 'AutoPrintr.CheckBoxSlider.SetToolTip(System.Windows.Forms.ToolTip,System.String)')
- [Config](#T-AutoPrintr-Config 'AutoPrintr.Config')
  - [#ctor(onError)](#M-AutoPrintr-Config-#ctor-System-Action{System-Exception}- 'AutoPrintr.Config.#ctor(System.Action{System.Exception})')
  - [load()](#M-AutoPrintr-Config-load 'AutoPrintr.Config.load')
  - [save()](#M-AutoPrintr-Config-save 'AutoPrintr.Config.save')
- [Converter](#T-AutoPrintr-PrintEngines-Converter 'AutoPrintr.PrintEngines.Converter')
  - [CanConvert(objectType)](#M-AutoPrintr-PrintEngines-Converter-CanConvert-System-Type- 'AutoPrintr.PrintEngines.Converter.CanConvert(System.Type)')
  - [ReadJson(reader,objectType,existingValue,serializer)](#M-AutoPrintr-PrintEngines-Converter-ReadJson-Newtonsoft-Json-JsonReader,System-Type,System-Object,Newtonsoft-Json-JsonSerializer- 'AutoPrintr.PrintEngines.Converter.ReadJson(Newtonsoft.Json.JsonReader,System.Type,System.Object,Newtonsoft.Json.JsonSerializer)')
  - [WriteJson(writer,value,serializer)](#M-AutoPrintr-PrintEngines-Converter-WriteJson-Newtonsoft-Json-JsonWriter,System-Object,Newtonsoft-Json-JsonSerializer- 'AutoPrintr.PrintEngines.Converter.WriteJson(Newtonsoft.Json.JsonWriter,System.Object,Newtonsoft.Json.JsonSerializer)')
- [Credentials](#T-AutoPrintr-Credentials 'AutoPrintr.Credentials')
  - [SrvXT](#F-AutoPrintr-Credentials-SrvXT 'AutoPrintr.Credentials.SrvXT')
- [DocQuantity](#T-AutoPrintr-DocQuantity 'AutoPrintr.DocQuantity')
- [DocType](#T-AutoPrintr-DocType 'AutoPrintr.DocType')
- [DocTypeCheckBox](#T-AutoPrintr-DocTypeCheckBox 'AutoPrintr.DocTypeCheckBox')
  - [docType](#F-AutoPrintr-DocTypeCheckBox-docType 'AutoPrintr.DocTypeCheckBox.docType')
- [DocumentType](#T-AutoPrintr-DocumentType 'AutoPrintr.DocumentType')
  - [#ctor(type,title)](#M-AutoPrintr-DocumentType-#ctor-AutoPrintr-DocType,System-String- 'AutoPrintr.DocumentType.#ctor(AutoPrintr.DocType,System.String)')
  - [name](#F-AutoPrintr-DocumentType-name 'AutoPrintr.DocumentType.name')
  - [title](#F-AutoPrintr-DocumentType-title 'AutoPrintr.DocumentType.title')
  - [type](#F-AutoPrintr-DocumentType-type 'AutoPrintr.DocumentType.type')
  - [ToString()](#M-AutoPrintr-DocumentType-ToString 'AutoPrintr.DocumentType.ToString')
- [DocumentTypes](#T-AutoPrintr-DocumentTypes 'AutoPrintr.DocumentTypes')
  - [list](#F-AutoPrintr-DocumentTypes-list 'AutoPrintr.DocumentTypes.list')
  - [init()](#M-AutoPrintr-DocumentTypes-init 'AutoPrintr.DocumentTypes.init')
  - [ToDocumentType(str)](#M-AutoPrintr-DocumentTypes-ToDocumentType-System-String- 'AutoPrintr.DocumentTypes.ToDocumentType(System.String)')
  - [toTitle(str)](#M-AutoPrintr-DocumentTypes-toTitle-System-String- 'AutoPrintr.DocumentTypes.toTitle(System.String)')
- [GHRelease](#T-AutoPrintr-Autoupdate-GHRelease 'AutoPrintr.Autoupdate.GHRelease')
- [JLHeaderLabel](#T-AutoPrintr-JobsList-JLHeaderLabel 'AutoPrintr.JobsList.JLHeaderLabel')
  - [#ctor(text)](#M-AutoPrintr-JobsList-JLHeaderLabel-#ctor-System-String- 'AutoPrintr.JobsList.JLHeaderLabel.#ctor(System.String)')
- [Job](#T-AutoPrintr-Job 'AutoPrintr.Job')
  - [#ctor(document,file,location,type)](#M-AutoPrintr-Job-#ctor-System-String,System-String,System-Int32,System-String,System-Boolean,System-Int32- 'AutoPrintr.Job.#ctor(System.String,System.String,System.Int32,System.String,System.Boolean,System.Int32)')
  - [documentTitle](#F-AutoPrintr-Job-documentTitle 'AutoPrintr.Job.documentTitle')
  - [err](#F-AutoPrintr-Job-err 'AutoPrintr.Job.err')
  - [fileName](#F-AutoPrintr-Job-fileName 'AutoPrintr.Job.fileName')
  - [localFileName](#F-AutoPrintr-Job-localFileName 'AutoPrintr.Job.localFileName')
  - [localFilePath](#F-AutoPrintr-Job-localFilePath 'AutoPrintr.Job.localFilePath')
  - [printer](#F-AutoPrintr-Job-printer 'AutoPrintr.Job.printer')
  - [progress](#F-AutoPrintr-Job-progress 'AutoPrintr.Job.progress')
  - [qty](#F-AutoPrintr-Job-qty 'AutoPrintr.Job.qty')
  - [recived](#F-AutoPrintr-Job-recived 'AutoPrintr.Job.recived')
  - [state](#F-AutoPrintr-Job-state 'AutoPrintr.Job.state')
  - [url](#F-AutoPrintr-Job-url 'AutoPrintr.Job.url')
  - [download(cb)](#M-AutoPrintr-Job-download-System-Action{System-Exception}- 'AutoPrintr.Job.download(System.Action{System.Exception})')
  - [Downloaded()](#M-AutoPrintr-Job-Downloaded 'AutoPrintr.Job.Downloaded')
  - [Downloading()](#M-AutoPrintr-Job-Downloading 'AutoPrintr.Job.Downloading')
  - [Error()](#M-AutoPrintr-Job-Error 'AutoPrintr.Job.Error')
  - [onDnProgress(sender,e)](#M-AutoPrintr-Job-onDnProgress-System-Object,System-Net-DownloadProgressChangedEventArgs- 'AutoPrintr.Job.onDnProgress(System.Object,System.Net.DownloadProgressChangedEventArgs)')
  - [print(cb)](#M-AutoPrintr-Job-print-System-Action{System-Exception}- 'AutoPrintr.Job.print(System.Action{System.Exception})')
  - [Printed()](#M-AutoPrintr-Job-Printed 'AutoPrintr.Job.Printed')
  - [Printing()](#M-AutoPrintr-Job-Printing 'AutoPrintr.Job.Printing')
  - [Processing()](#M-AutoPrintr-Job-Processing 'AutoPrintr.Job.Processing')
  - [quantity()](#M-AutoPrintr-Job-quantity 'AutoPrintr.Job.quantity')
  - [Skipped()](#M-AutoPrintr-Job-Skipped-System-Int32- 'AutoPrintr.Job.Skipped(System.Int32)')
  - [ToString()](#M-AutoPrintr-Job-ToString 'AutoPrintr.Job.ToString')
- [JobMsg](#T-AutoPrintr-JobMsg 'AutoPrintr.JobMsg')
- [Jobs](#T-AutoPrintr-Jobs 'AutoPrintr.Jobs')
  - [list](#F-AutoPrintr-Jobs-list 'AutoPrintr.Jobs.list')
  - [newJobEvent](#F-AutoPrintr-Jobs-newJobEvent 'AutoPrintr.Jobs.newJobEvent')
  - [init(channel,onJob)](#M-AutoPrintr-Jobs-init-System-String,System-Action{System-Exception,AutoPrintr-Job}- 'AutoPrintr.Jobs.init(System.String,System.Action{System.Exception,AutoPrintr.Job})')
  - [msgValidate(msg)](#M-AutoPrintr-Jobs-msgValidate-System-Object- 'AutoPrintr.Jobs.msgValidate(System.Object)')
- [JobsList](#T-AutoPrintr-Jobs-JobsList 'AutoPrintr.Jobs.JobsList')
- [JobsList](#T-AutoPrintr-JobsList 'AutoPrintr.JobsList')
  - [#ctor()](#M-AutoPrintr-JobsList-#ctor 'AutoPrintr.JobsList.#ctor')
  - [components](#F-AutoPrintr-JobsList-components 'AutoPrintr.JobsList.components')
  - [headerItems](#F-AutoPrintr-JobsList-headerItems 'AutoPrintr.JobsList.headerItems')
  - [items](#F-AutoPrintr-JobsList-items 'AutoPrintr.JobsList.items')
  - [add(job)](#M-AutoPrintr-JobsList-add-AutoPrintr-Job- 'AutoPrintr.JobsList.add(AutoPrintr.Job)')
  - [addColumn(name)](#M-AutoPrintr-JobsList-addColumn-System-String- 'AutoPrintr.JobsList.addColumn(System.String)')
  - [addJobControls(uiJob)](#M-AutoPrintr-JobsList-addJobControls-AutoPrintr-JobsList-UIJob- 'AutoPrintr.JobsList.addJobControls(AutoPrintr.JobsList.UIJob)')
  - [Dispose(disposing)](#M-AutoPrintr-JobsList-Dispose-System-Boolean- 'AutoPrintr.JobsList.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-AutoPrintr-JobsList-InitializeComponent 'AutoPrintr.JobsList.InitializeComponent')
  - [update(uiJob,j)](#M-AutoPrintr-JobsList-update-AutoPrintr-JobsList-UIJob,AutoPrintr-Job- 'AutoPrintr.JobsList.update(AutoPrintr.JobsList.UIJob,AutoPrintr.Job)')
- [JobsListLabel](#T-AutoPrintr-JobsList-JobsListLabel 'AutoPrintr.JobsList.JobsListLabel')
  - [#ctor(text)](#M-AutoPrintr-JobsList-JobsListLabel-#ctor-System-String- 'AutoPrintr.JobsList.JobsListLabel.#ctor(System.String)')
- [JobsServer](#T-AutoPrintr-JobsServer 'AutoPrintr.JobsServer')
  - [channels](#F-AutoPrintr-JobsServer-channels 'AutoPrintr.JobsServer.channels')
  - [pusher](#F-AutoPrintr-JobsServer-pusher 'AutoPrintr.JobsServer.pusher')
  - [state](#F-AutoPrintr-JobsServer-state 'AutoPrintr.JobsServer.state')
  - [connect(listeners,onError,onStateChanged)](#M-AutoPrintr-JobsServer-connect-System-Collections-Generic-List{AutoPrintr-Listener},System-Action{PusherClient-PusherException},System-Action{System-String}- 'AutoPrintr.JobsServer.connect(System.Collections.Generic.List{AutoPrintr.Listener},System.Action{PusherClient.PusherException},System.Action{System.String})')
- [JobState](#T-AutoPrintr-JobState 'AutoPrintr.JobState')
- [Listener](#T-AutoPrintr-Listener 'AutoPrintr.Listener')
  - [#ctor(channel,evt,onMessage)](#M-AutoPrintr-Listener-#ctor-System-String,System-String,System-Action{System-Object}- 'AutoPrintr.Listener.#ctor(System.String,System.String,System.Action{System.Object})')
  - [channel](#F-AutoPrintr-Listener-channel 'AutoPrintr.Listener.channel')
  - [evt](#F-AutoPrintr-Listener-evt 'AutoPrintr.Listener.evt')
  - [onMessage](#F-AutoPrintr-Listener-onMessage 'AutoPrintr.Listener.onMessage')
- [LogConfig](#T-AutoPrintr-LogConfig 'AutoPrintr.LogConfig')
  - [logConfigFile](#F-AutoPrintr-LogConfig-logConfigFile 'AutoPrintr.LogConfig.logConfigFile')
  - [LogLevels](#F-AutoPrintr-LogConfig-LogLevels 'AutoPrintr.LogConfig.LogLevels')
  - [NLog2UserLogName](#F-AutoPrintr-LogConfig-NLog2UserLogName 'AutoPrintr.LogConfig.NLog2UserLogName')
  - [UserLogName2NLog](#F-AutoPrintr-LogConfig-UserLogName2NLog 'AutoPrintr.LogConfig.UserLogName2NLog')
  - [logLevel(level)](#M-AutoPrintr-LogConfig-logLevel-System-String- 'AutoPrintr.LogConfig.logLevel(System.String)')
- [LoginResponse](#T-AutoPrintr-LoginResponse 'AutoPrintr.LoginResponse')
- [LoginServer](#T-AutoPrintr-LoginServer 'AutoPrintr.LoginServer')
  - [channel](#F-AutoPrintr-LoginServer-channel 'AutoPrintr.LoginServer.channel')
  - [defaultLocation](#F-AutoPrintr-LoginServer-defaultLocation 'AutoPrintr.LoginServer.defaultLocation')
  - [domain](#F-AutoPrintr-LoginServer-domain 'AutoPrintr.LoginServer.domain')
  - [isMultiLocations](#F-AutoPrintr-LoginServer-isMultiLocations 'AutoPrintr.LoginServer.isMultiLocations')
  - [locationID2String](#F-AutoPrintr-LoginServer-locationID2String 'AutoPrintr.LoginServer.locationID2String')
  - [locations](#F-AutoPrintr-LoginServer-locations 'AutoPrintr.LoginServer.locations')
  - [locationString2ID](#F-AutoPrintr-LoginServer-locationString2ID 'AutoPrintr.LoginServer.locationString2ID')
  - [registers](#F-AutoPrintr-LoginServer-registers 'AutoPrintr.LoginServer.registers')
  - [serverUrl](#F-AutoPrintr-LoginServer-serverUrl 'AutoPrintr.LoginServer.serverUrl')
  - [UserToken](#F-AutoPrintr-LoginServer-UserToken 'AutoPrintr.LoginServer.UserToken')
  - [getSettings(domain,host,xt)](#M-AutoPrintr-LoginServer-getSettings-System-String,System-String,System-String- 'AutoPrintr.LoginServer.getSettings(System.String,System.String,System.String)')
  - [login(username,password)](#M-AutoPrintr-LoginServer-login-System-String,System-String- 'AutoPrintr.LoginServer.login(System.String,System.String)')
- [logLevels](#T-AutoPrintr-tools-logLevels 'AutoPrintr.tools.logLevels')
  - [Debug](#F-AutoPrintr-tools-logLevels-Debug 'AutoPrintr.tools.logLevels.Debug')
  - [Error](#F-AutoPrintr-tools-logLevels-Error 'AutoPrintr.tools.logLevels.Error')
  - [Fatal](#F-AutoPrintr-tools-logLevels-Fatal 'AutoPrintr.tools.logLevels.Fatal')
  - [Info](#F-AutoPrintr-tools-logLevels-Info 'AutoPrintr.tools.logLevels.Info')
  - [Trace](#F-AutoPrintr-tools-logLevels-Trace 'AutoPrintr.tools.logLevels.Trace')
  - [Warn](#F-AutoPrintr-tools-logLevels-Warn 'AutoPrintr.tools.logLevels.Warn')
- [LogWatcher](#T-AutoPrintr-LogWatcher 'AutoPrintr.LogWatcher')
  - [file](#F-AutoPrintr-LogWatcher-file 'AutoPrintr.LogWatcher.file')
- [mainWin](#T-AutoPrintr-mainWin 'AutoPrintr.mainWin')
  - [#ctor()](#M-AutoPrintr-mainWin-#ctor 'AutoPrintr.mainWin.#ctor')
  - [components](#F-AutoPrintr-mainWin-components 'AutoPrintr.mainWin.components')
  - [registersDD](#F-AutoPrintr-mainWin-registersDD 'AutoPrintr.mainWin.registersDD')
  - [aboutTabInit()](#M-AutoPrintr-mainWin-aboutTabInit 'AutoPrintr.mainWin.aboutTabInit')
  - [configTabInit()](#M-AutoPrintr-mainWin-configTabInit 'AutoPrintr.mainWin.configTabInit')
  - [createPrintersUI()](#M-AutoPrintr-mainWin-createPrintersUI 'AutoPrintr.mainWin.createPrintersUI')
  - [Dispose(disposing)](#M-AutoPrintr-mainWin-Dispose-System-Boolean- 'AutoPrintr.mainWin.Dispose(System.Boolean)')
  - [getLicenseText()](#M-AutoPrintr-mainWin-getLicenseText 'AutoPrintr.mainWin.getLicenseText')
  - [helpButton_Click(sender,e)](#M-AutoPrintr-mainWin-helpButton_Click-System-Object,System-EventArgs- 'AutoPrintr.mainWin.helpButton_Click(System.Object,System.EventArgs)')
  - [InitializeComponent()](#M-AutoPrintr-mainWin-InitializeComponent 'AutoPrintr.mainWin.InitializeComponent')
  - [logTabInit()](#M-AutoPrintr-mainWin-logTabInit 'AutoPrintr.mainWin.logTabInit')
  - [mainWin_Resize(sender,e)](#M-AutoPrintr-mainWin-mainWin_Resize-System-Object,System-EventArgs- 'AutoPrintr.mainWin.mainWin_Resize(System.Object,System.EventArgs)')
  - [onLogChange(o,e)](#M-AutoPrintr-mainWin-onLogChange-System-Object,System-EventArgs- 'AutoPrintr.mainWin.onLogChange(System.Object,System.EventArgs)')
  - [setStatus(str)](#M-AutoPrintr-mainWin-setStatus-System-String- 'AutoPrintr.mainWin.setStatus(System.String)')
  - [srvConnect()](#M-AutoPrintr-mainWin-srvConnect-System-String- 'AutoPrintr.mainWin.srvConnect(System.String)')
  - [submit_Click(sender,ev)](#M-AutoPrintr-mainWin-submit_Click-System-Object,System-EventArgs- 'AutoPrintr.mainWin.submit_Click(System.Object,System.EventArgs)')
  - [updateLocations(locations,defaultLocation)](#M-AutoPrintr-mainWin-updateLocations-System-Collections-Generic-List{AutoPrintr-Location},AutoPrintr-Location- 'AutoPrintr.mainWin.updateLocations(System.Collections.Generic.List{AutoPrintr.Location},AutoPrintr.Location)')
- [pLabel](#T-AutoPrintr-pLabel 'AutoPrintr.pLabel')
- [printDelegate](#T-AutoPrintr-PrintEngine-printDelegate 'AutoPrintr.PrintEngine.printDelegate')
- [PrintEngine](#T-AutoPrintr-PrintEngine 'AutoPrintr.PrintEngine')
  - [#ctor(name,printAction)](#M-AutoPrintr-PrintEngine-#ctor-System-String,AutoPrintr-PrintEngine-printDelegate- 'AutoPrintr.PrintEngine.#ctor(System.String,AutoPrintr.PrintEngine.printDelegate)')
  - [name](#F-AutoPrintr-PrintEngine-name 'AutoPrintr.PrintEngine.name')
  - [print](#F-AutoPrintr-PrintEngine-print 'AutoPrintr.PrintEngine.print')
  - [ToString()](#M-AutoPrintr-PrintEngine-ToString 'AutoPrintr.PrintEngine.ToString')
- [PrintEngineDD](#T-AutoPrintr-PrintEngineDD 'AutoPrintr.PrintEngineDD')
  - [#ctor(printer)](#M-AutoPrintr-PrintEngineDD-#ctor-AutoPrintr-Printer- 'AutoPrintr.PrintEngineDD.#ctor(AutoPrintr.Printer)')
  - [printer](#F-AutoPrintr-PrintEngineDD-printer 'AutoPrintr.PrintEngineDD.printer')
  - [PrintEngineDD_TextChanged(sender,e)](#M-AutoPrintr-PrintEngineDD-PrintEngineDD_TextChanged-System-Object,System-EventArgs- 'AutoPrintr.PrintEngineDD.PrintEngineDD_TextChanged(System.Object,System.EventArgs)')
- [PrintEngines](#T-AutoPrintr-PrintEngines 'AutoPrintr.PrintEngines')
  - [AcrobatReader](#F-AutoPrintr-PrintEngines-AcrobatReader 'AutoPrintr.PrintEngines.AcrobatReader')
  - [Default](#F-AutoPrintr-PrintEngines-Default 'AutoPrintr.PrintEngines.Default')
  - [DefaultPdfReader](#F-AutoPrintr-PrintEngines-DefaultPdfReader 'AutoPrintr.PrintEngines.DefaultPdfReader')
  - [list](#F-AutoPrintr-PrintEngines-list 'AutoPrintr.PrintEngines.list')
  - [SumatraPDF](#F-AutoPrintr-PrintEngines-SumatraPDF 'AutoPrintr.PrintEngines.SumatraPDF')
  - [find(engineName)](#M-AutoPrintr-PrintEngines-find-System-String- 'AutoPrintr.PrintEngines.find(System.String)')
- [Printer](#T-AutoPrintr-Printer 'AutoPrintr.Printer')
  - [#ctor(name,types,r,l)](#M-AutoPrintr-Printer-#ctor-System-String,System-Collections-Generic-List{AutoPrintr-DocType}- 'AutoPrintr.Printer.#ctor(System.String,System.Collections.Generic.List{AutoPrintr.DocType})')
  - [print(filePath,documentName)](#M-AutoPrintr-Printer-print-System-String,System-String,System-String- 'AutoPrintr.Printer.print(System.String,System.String,System.String)')
  - [ToString()](#M-AutoPrintr-Printer-ToString 'AutoPrintr.Printer.ToString')
  - [triggerGet(type)](#M-AutoPrintr-Printer-triggerGet-AutoPrintr-DocType- 'AutoPrintr.Printer.triggerGet(AutoPrintr.DocType)')
  - [triggerSet(type,val)](#M-AutoPrintr-Printer-triggerSet-AutoPrintr-DocType,System-Boolean- 'AutoPrintr.Printer.triggerSet(AutoPrintr.DocType,System.Boolean)')
  - [typeGet(type)](#M-AutoPrintr-Printer-typeGet-AutoPrintr-DocType- 'AutoPrintr.Printer.typeGet(AutoPrintr.DocType)')
  - [typeSet(type,val)](#M-AutoPrintr-Printer-typeSet-AutoPrintr-DocType,System-Boolean- 'AutoPrintr.Printer.typeSet(AutoPrintr.DocType,System.Boolean)')
- [PrinterDocumentControl](#T-AutoPrintr-PrinterDocumentControl 'AutoPrintr.PrinterDocumentControl')
  - [components](#F-AutoPrintr-PrinterDocumentControl-components 'AutoPrintr.PrinterDocumentControl.components')
  - [Dispose(disposing)](#M-AutoPrintr-PrinterDocumentControl-Dispose-System-Boolean- 'AutoPrintr.PrinterDocumentControl.Dispose(System.Boolean)')
  - [InitializeComponent()](#M-AutoPrintr-PrinterDocumentControl-InitializeComponent 'AutoPrintr.PrinterDocumentControl.InitializeComponent')
- [Printers](#T-AutoPrintr-Printers 'AutoPrintr.Printers')
  - [findPrinters(type,location,register)](#M-AutoPrintr-Printers-findPrinters-System-String,System-Int32,System-Int32- 'AutoPrintr.Printers.findPrinters(System.String,System.Int32,System.Int32)')
  - [get()](#M-AutoPrintr-Printers-get 'AutoPrintr.Printers.get')
  - [init()](#M-AutoPrintr-Printers-init 'AutoPrintr.Printers.init')
- [Program](#T-AutoPrintr-Program 'AutoPrintr.Program')
  - [appInitString](#F-AutoPrintr-Program-appInitString 'AutoPrintr.Program.appInitString')
  - [config](#F-AutoPrintr-Program-config 'AutoPrintr.Program.config')
  - [tempDir](#F-AutoPrintr-Program-tempDir 'AutoPrintr.Program.tempDir')
  - [tempDnDir](#F-AutoPrintr-Program-tempDnDir 'AutoPrintr.Program.tempDnDir')
  - [window](#F-AutoPrintr-Program-window 'AutoPrintr.Program.window')
  - [Main()](#M-AutoPrintr-Program-Main-System-String[]- 'AutoPrintr.Program.Main(System.String[])')
- [Register](#T-AutoPrintr-LoginServer-Register 'AutoPrintr.LoginServer.Register')
- [RegisterDD](#T-AutoPrintr-RegisterDD 'AutoPrintr.RegisterDD')
  - [#ctor(printer)](#M-AutoPrintr-RegisterDD-#ctor-AutoPrintr-Printer,System-Collections-Generic-List{AutoPrintr-LoginServer-Register}- 'AutoPrintr.RegisterDD.#ctor(AutoPrintr.Printer,System.Collections.Generic.List{AutoPrintr.LoginServer.Register})')
  - [printer](#F-AutoPrintr-RegisterDD-printer 'AutoPrintr.RegisterDD.printer')
  - [RegisterDD_TextChanged(sender,e)](#M-AutoPrintr-RegisterDD-RegisterDD_TextChanged-System-Object,System-EventArgs- 'AutoPrintr.RegisterDD.RegisterDD_TextChanged(System.Object,System.EventArgs)')
- [Resources](#T-AutoPrintr-Properties-Resources 'AutoPrintr.Properties.Resources')
  - [Culture](#P-AutoPrintr-Properties-Resources-Culture 'AutoPrintr.Properties.Resources.Culture')
  - [ResourceManager](#P-AutoPrintr-Properties-Resources-ResourceManager 'AutoPrintr.Properties.Resources.ResourceManager')
- [setStatusCb](#T-AutoPrintr-mainWin-setStatusCb 'AutoPrintr.mainWin.setStatusCb')
- [Settings](#T-AutoPrintr-Settings 'AutoPrintr.Settings')
  - [availableLocations](#F-AutoPrintr-Settings-availableLocations 'AutoPrintr.Settings.availableLocations')
  - [channel](#F-AutoPrintr-Settings-channel 'AutoPrintr.Settings.channel')
  - [locations](#F-AutoPrintr-Settings-locations 'AutoPrintr.Settings.locations')
  - [login](#F-AutoPrintr-Settings-login 'AutoPrintr.Settings.login')
  - [printers](#F-AutoPrintr-Settings-printers 'AutoPrintr.Settings.printers')
  - [registers](#F-AutoPrintr-Settings-registers 'AutoPrintr.Settings.registers')
- [Skin](#T-AutoPrintr-Skins-Skin 'AutoPrintr.Skins.Skin')
  - [apply(control)](#M-AutoPrintr-Skins-Skin-apply-System-Windows-Forms-Control- 'AutoPrintr.Skins.Skin.apply(System.Windows.Forms.Control)')
- [SkinCheckBox](#T-AutoPrintr-Skins-SkinCheckBox 'AutoPrintr.Skins.SkinCheckBox')
- [SkinConfig](#T-AutoPrintr-Skins-SkinConfig 'AutoPrintr.Skins.SkinConfig')
- [skinFont](#T-AutoPrintr-Skins-skinFont 'AutoPrintr.Skins.skinFont')
- [SkinForControl](#T-AutoPrintr-Skins-SkinForControl 'AutoPrintr.Skins.SkinForControl')
  - [apply(control)](#M-AutoPrintr-Skins-SkinForControl-apply-System-Windows-Forms-Control- 'AutoPrintr.Skins.SkinForControl.apply(System.Windows.Forms.Control)')
- [Skins](#T-AutoPrintr-Skins 'AutoPrintr.Skins')
  - [config](#F-AutoPrintr-Skins-config 'AutoPrintr.Skins.config')
  - [file](#F-AutoPrintr-Skins-file 'AutoPrintr.Skins.file')
  - [fileExample](#F-AutoPrintr-Skins-fileExample 'AutoPrintr.Skins.fileExample')
- [tabelLabel](#T-AutoPrintr-tabelLabel 'AutoPrintr.tabelLabel')
- [tools](#T-AutoPrintr-tools 'AutoPrintr.tools')
  - [shortVersion](#F-AutoPrintr-tools-shortVersion 'AutoPrintr.tools.shortVersion')
  - [version](#F-AutoPrintr-tools-version 'AutoPrintr.tools.version')
  - [BytesToString(byteCount)](#M-AutoPrintr-tools-BytesToString-System-Int64- 'AutoPrintr.tools.BytesToString(System.Int64)')
  - [Color2RGB(c)](#M-AutoPrintr-tools-Color2RGB-System-Drawing-Color- 'AutoPrintr.tools.Color2RGB(System.Drawing.Color)')
  - [DirEmpty(path)](#M-AutoPrintr-tools-DirEmpty-System-String- 'AutoPrintr.tools.DirEmpty(System.String)')
  - [GET(Url)](#M-AutoPrintr-tools-GET-System-String- 'AutoPrintr.tools.GET(System.String)')
  - [GetAllControls(container)](#M-AutoPrintr-tools-GetAllControls-System-Windows-Forms-Control- 'AutoPrintr.tools.GetAllControls(System.Windows.Forms.Control)')
  - [randomFileName()](#M-AutoPrintr-tools-randomFileName 'AutoPrintr.tools.randomFileName')
  - [RGB2Color(s)](#M-AutoPrintr-tools-RGB2Color-System-String- 'AutoPrintr.tools.RGB2Color(System.String)')
  - [SetAllowUnsafeHeaderParsing20()](#M-AutoPrintr-tools-SetAllowUnsafeHeaderParsing20 'AutoPrintr.tools.SetAllowUnsafeHeaderParsing20')
- [TriggerCheckBox](#T-AutoPrintr-TriggerCheckBox 'AutoPrintr.TriggerCheckBox')
  - [docType](#F-AutoPrintr-TriggerCheckBox-docType 'AutoPrintr.TriggerCheckBox.docType')
  - [printer](#F-AutoPrintr-TriggerCheckBox-printer 'AutoPrintr.TriggerCheckBox.printer')
  - [ttText](#F-AutoPrintr-TriggerCheckBox-ttText 'AutoPrintr.TriggerCheckBox.ttText')
- [UIJob](#T-AutoPrintr-JobsList-UIJob 'AutoPrintr.JobsList.UIJob')
  - [#ctor(job,row,index)](#M-AutoPrintr-JobsList-UIJob-#ctor-AutoPrintr-Job,System-Int32,System-Int32- 'AutoPrintr.JobsList.UIJob.#ctor(AutoPrintr.Job,System.Int32,System.Int32)')
  - [update(job)](#M-AutoPrintr-JobsList-UIJob-update-AutoPrintr-Job- 'AutoPrintr.JobsList.UIJob.update(AutoPrintr.Job)')
- [updateCb](#T-AutoPrintr-JobsList-updateCb 'AutoPrintr.JobsList.updateCb')
- [WinAutoSize](#T-AutoPrintr-WinAutoSize 'AutoPrintr.WinAutoSize')
  - [apply(win,controls)](#M-AutoPrintr-WinAutoSize-apply-AutoPrintr-mainWin,System-Windows-Forms-Control[]- 'AutoPrintr.WinAutoSize.apply(AutoPrintr.mainWin,System.Windows.Forms.Control[])')
  - [getClientLocation(win,control)](#M-AutoPrintr-WinAutoSize-getClientLocation-AutoPrintr-mainWin,System-Windows-Forms-Control- 'AutoPrintr.WinAutoSize.getClientLocation(AutoPrintr.mainWin,System.Windows.Forms.Control)')

<a name='assembly'></a>
# AutoPrintr [#](#assembly 'Go To Here') [=](#contents 'Back To Contents')

<a name='T-AutoPrintr-JobsList-addJobControlsCb'></a>
## addJobControlsCb [#](#T-AutoPrintr-JobsList-addJobControlsCb 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.JobsList

##### Summary

Delegate for adding controls for job in UI

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uiJob | [T:AutoPrintr.JobsList.addJobControlsCb](#T-T-AutoPrintr-JobsList-addJobControlsCb 'T:AutoPrintr.JobsList.addJobControlsCb') |  |

<a name='T-AutoPrintr-CheckBoxList'></a>
## CheckBoxList [#](#T-AutoPrintr-CheckBoxList 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Checkboxes list UI control

<a name='F-AutoPrintr-CheckBoxList-components'></a>
### components `constants` [#](#F-AutoPrintr-CheckBoxList-components 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Требуется переменная конструктора.

<a name='M-AutoPrintr-CheckBoxList-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method` [#](#M-AutoPrintr-CheckBoxList-Dispose-System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Освободить все используемые ресурсы.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | истинно, если управляемый ресурс должен быть удален; иначе ложно. |

<a name='M-AutoPrintr-CheckBoxList-InitializeComponent'></a>
### InitializeComponent() `method` [#](#M-AutoPrintr-CheckBoxList-InitializeComponent 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Обязательный метод для поддержки конструктора - не изменяйте содержимое данного метода при помощи редактора кода.

##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-CheckBoxListItem'></a>
## CheckBoxListItem [#](#T-AutoPrintr-CheckBoxListItem 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

CheckBox list item

<a name='T-AutoPrintr-CheckBoxSlider'></a>
## CheckBoxSlider [#](#T-AutoPrintr-CheckBoxSlider 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Custom checkbox of slider type with gradients and border

<a name='F-AutoPrintr-CheckBoxSlider-_checked'></a>
### _checked `constants` [#](#F-AutoPrintr-CheckBoxSlider-_checked 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Time of animation in ms

<a name='F-AutoPrintr-CheckBoxSlider-Changed'></a>
### Changed `constants` [#](#F-AutoPrintr-CheckBoxSlider-Changed 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

State change event

<a name='F-AutoPrintr-CheckBoxSlider-Click'></a>
### Click `constants` [#](#F-AutoPrintr-CheckBoxSlider-Click 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Click event

<a name='F-AutoPrintr-CheckBoxSlider-components'></a>
### components `constants` [#](#F-AutoPrintr-CheckBoxSlider-components 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Требуется переменная конструктора.

<a name='M-AutoPrintr-CheckBoxSlider-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method` [#](#M-AutoPrintr-CheckBoxSlider-Dispose-System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Освободить все используемые ресурсы.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | истинно, если управляемый ресурс должен быть удален; иначе ложно. |

<a name='M-AutoPrintr-CheckBoxSlider-InitializeComponent'></a>
### InitializeComponent() `method` [#](#M-AutoPrintr-CheckBoxSlider-InitializeComponent 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Обязательный метод для поддержки конструктора - не изменяйте содержимое данного метода при помощи редактора кода.

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-CheckBoxSlider-SetToolTip-System-Windows-Forms-ToolTip,System-String-'></a>
### SetToolTip(tt,text) `method` [#](#M-AutoPrintr-CheckBoxSlider-SetToolTip-System-Windows-Forms-ToolTip,System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set tooltip for this checkbox

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tt | [System.Windows.Forms.ToolTip](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.ToolTip 'System.Windows.Forms.ToolTip') |  |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-Config'></a>
## Config [#](#T-AutoPrintr-Config 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Application config manager class - read, write config, load, save setting to file

<a name='M-AutoPrintr-Config-#ctor-System-Action{System-Exception}-'></a>
### #ctor(onError) `constructor` [#](#M-AutoPrintr-Config-#ctor-System-Action{System-Exception}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

New config instance

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| onError | [System.Action{System.Exception}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Exception}') |  |

<a name='M-AutoPrintr-Config-load'></a>
### load() `method` [#](#M-AutoPrintr-Config-load 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Load configuration

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Config-save'></a>
### save() `method` [#](#M-AutoPrintr-Config-save 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Save current configuration

##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-PrintEngines-Converter'></a>
## Converter [#](#T-AutoPrintr-PrintEngines-Converter 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.PrintEngines

##### Summary

PrintEngine JSON converter

<a name='M-AutoPrintr-PrintEngines-Converter-CanConvert-System-Type-'></a>
### CanConvert(objectType) `method` [#](#M-AutoPrintr-PrintEngines-Converter-CanConvert-System-Type- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Check if object type can be mapped to print engine

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| objectType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |

<a name='M-AutoPrintr-PrintEngines-Converter-ReadJson-Newtonsoft-Json-JsonReader,System-Type,System-Object,Newtonsoft-Json-JsonSerializer-'></a>
### ReadJson(reader,objectType,existingValue,serializer) `method` [#](#M-AutoPrintr-PrintEngines-Converter-ReadJson-Newtonsoft-Json-JsonReader,System-Type,System-Object,Newtonsoft-Json-JsonSerializer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert string print engine name to engine instance

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [Newtonsoft.Json.JsonReader](#T-Newtonsoft-Json-JsonReader 'Newtonsoft.Json.JsonReader') |  |
| objectType | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') |  |
| existingValue | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| serializer | [Newtonsoft.Json.JsonSerializer](#T-Newtonsoft-Json-JsonSerializer 'Newtonsoft.Json.JsonSerializer') |  |

<a name='M-AutoPrintr-PrintEngines-Converter-WriteJson-Newtonsoft-Json-JsonWriter,System-Object,Newtonsoft-Json-JsonSerializer-'></a>
### WriteJson(writer,value,serializer) `method` [#](#M-AutoPrintr-PrintEngines-Converter-WriteJson-Newtonsoft-Json-JsonWriter,System-Object,Newtonsoft-Json-JsonSerializer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert print engine instance to string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| writer | [Newtonsoft.Json.JsonWriter](#T-Newtonsoft-Json-JsonWriter 'Newtonsoft.Json.JsonWriter') |  |
| value | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| serializer | [Newtonsoft.Json.JsonSerializer](#T-Newtonsoft-Json-JsonSerializer 'Newtonsoft.Json.JsonSerializer') |  |

<a name='T-AutoPrintr-Credentials'></a>
## Credentials [#](#T-AutoPrintr-Credentials 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Class for credentials storing

<a name='F-AutoPrintr-Credentials-SrvXT'></a>
### SrvXT `constants` [#](#F-AutoPrintr-Credentials-SrvXT 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Pusher API key

<a name='T-AutoPrintr-DocQuantity'></a>
## DocQuantity [#](#T-AutoPrintr-DocQuantity 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Printer document type number documents to print

<a name='T-AutoPrintr-DocType'></a>
## DocType [#](#T-AutoPrintr-DocType 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Document types id list

<a name='T-AutoPrintr-DocTypeCheckBox'></a>
## DocTypeCheckBox [#](#T-AutoPrintr-DocTypeCheckBox 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Printer document type checkbox

<a name='F-AutoPrintr-DocTypeCheckBox-docType'></a>
### docType `constants` [#](#F-AutoPrintr-DocTypeCheckBox-docType 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Document type

<a name='T-AutoPrintr-DocumentType'></a>
## DocumentType [#](#T-AutoPrintr-DocumentType 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Document type class

<a name='M-AutoPrintr-DocumentType-#ctor-AutoPrintr-DocType,System-String-'></a>
### #ctor(type,title) `constructor` [#](#M-AutoPrintr-DocumentType-#ctor-AutoPrintr-DocType,System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

DocumentType constructor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [AutoPrintr.DocType](#T-AutoPrintr-DocType 'AutoPrintr.DocType') |  |
| title | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='F-AutoPrintr-DocumentType-name'></a>
### name `constants` [#](#F-AutoPrintr-DocumentType-name 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Document type name (string)

<a name='F-AutoPrintr-DocumentType-title'></a>
### title `constants` [#](#F-AutoPrintr-DocumentType-title 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Document type human redeable string

<a name='F-AutoPrintr-DocumentType-type'></a>
### type `constants` [#](#F-AutoPrintr-DocumentType-type 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Document type ID

<a name='M-AutoPrintr-DocumentType-ToString'></a>
### ToString() `method` [#](#M-AutoPrintr-DocumentType-ToString 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert to string

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-DocumentTypes'></a>
## DocumentTypes [#](#T-AutoPrintr-DocumentTypes 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Document types manager

<a name='F-AutoPrintr-DocumentTypes-list'></a>
### list `constants` [#](#F-AutoPrintr-DocumentTypes-list 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Available document types

<a name='M-AutoPrintr-DocumentTypes-init'></a>
### init() `method` [#](#M-AutoPrintr-DocumentTypes-init 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Initialization method

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-DocumentTypes-ToDocumentType-System-String-'></a>
### ToDocumentType(str) `method` [#](#M-AutoPrintr-DocumentTypes-ToDocumentType-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get DocumentType object from string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-DocumentTypes-toTitle-System-String-'></a>
### toTitle(str) `method` [#](#M-AutoPrintr-DocumentTypes-toTitle-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert document type string to human readable string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-Autoupdate-GHRelease'></a>
## GHRelease [#](#T-AutoPrintr-Autoupdate-GHRelease 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Autoupdate

##### Summary

Github API releases response

<a name='T-AutoPrintr-JobsList-JLHeaderLabel'></a>
## JLHeaderLabel [#](#T-AutoPrintr-JobsList-JLHeaderLabel 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.JobsList

##### Summary

Label for JobsList header

<a name='M-AutoPrintr-JobsList-JLHeaderLabel-#ctor-System-String-'></a>
### #ctor(text) `constructor` [#](#M-AutoPrintr-JobsList-JLHeaderLabel-#ctor-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new label for JobsList header

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-Job'></a>
## Job [#](#T-AutoPrintr-Job 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Job presentation class

<a name='M-AutoPrintr-Job-#ctor-System-String,System-String,System-Int32,System-String,System-Boolean,System-Int32-'></a>
### #ctor(document,file,location,type) `constructor` [#](#M-AutoPrintr-Job-#ctor-System-String,System-String,System-Int32,System-String,System-Boolean,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

New job consturctor

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| document | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| file | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| location | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='F-AutoPrintr-Job-documentTitle'></a>
### documentTitle `constants` [#](#F-AutoPrintr-Job-documentTitle 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Document title - human redable job document type.

<a name='F-AutoPrintr-Job-err'></a>
### err `constants` [#](#F-AutoPrintr-Job-err 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job error

<a name='F-AutoPrintr-Job-fileName'></a>
### fileName `constants` [#](#F-AutoPrintr-Job-fileName 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Only file name

<a name='F-AutoPrintr-Job-localFileName'></a>
### localFileName `constants` [#](#F-AutoPrintr-Job-localFileName 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Local file name

<a name='F-AutoPrintr-Job-localFilePath'></a>
### localFilePath `constants` [#](#F-AutoPrintr-Job-localFilePath 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Full path to local file, where job file will be downloaded. Have random additional string.

<a name='F-AutoPrintr-Job-printer'></a>
### printer `constants` [#](#F-AutoPrintr-Job-printer 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

List of associated with this job printers

<a name='F-AutoPrintr-Job-progress'></a>
### progress `constants` [#](#F-AutoPrintr-Job-progress 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job download progress in percents

<a name='F-AutoPrintr-Job-qty'></a>
### qty `constants` [#](#F-AutoPrintr-Job-qty 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Qauntity

<a name='F-AutoPrintr-Job-recived'></a>
### recived `constants` [#](#F-AutoPrintr-Job-recived 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job download progress in bytes

<a name='F-AutoPrintr-Job-state'></a>
### state `constants` [#](#F-AutoPrintr-Job-state 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job state

<a name='F-AutoPrintr-Job-url'></a>
### url `constants` [#](#F-AutoPrintr-Job-url 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job file url parsed to URI object

<a name='M-AutoPrintr-Job-download-System-Action{System-Exception}-'></a>
### download(cb) `method` [#](#M-AutoPrintr-Job-download-System-Action{System-Exception}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job file download method

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cb | [System.Action{System.Exception}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Exception}') |  |

<a name='M-AutoPrintr-Job-Downloaded'></a>
### Downloaded() `method` [#](#M-AutoPrintr-Job-Downloaded 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Downloaded"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-Downloading'></a>
### Downloading() `method` [#](#M-AutoPrintr-Job-Downloading 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Downloading"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-Error'></a>
### Error() `method` [#](#M-AutoPrintr-Job-Error 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Error"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-onDnProgress-System-Object,System-Net-DownloadProgressChangedEventArgs-'></a>
### onDnProgress(sender,e) `method` [#](#M-AutoPrintr-Job-onDnProgress-System-Object,System-Net-DownloadProgressChangedEventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job download progress event

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.Net.DownloadProgressChangedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.DownloadProgressChangedEventArgs 'System.Net.DownloadProgressChangedEventArgs') |  |

<a name='M-AutoPrintr-Job-print-System-Action{System-Exception}-'></a>
### print(cb) `method` [#](#M-AutoPrintr-Job-print-System-Action{System-Exception}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print job on selected printers

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| cb | [System.Action{System.Exception}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Exception}') |  |

<a name='M-AutoPrintr-Job-Printed'></a>
### Printed() `method` [#](#M-AutoPrintr-Job-Printed 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Printed"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-Printing'></a>
### Printing() `method` [#](#M-AutoPrintr-Job-Printing 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Printing"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-Processing'></a>
### Processing() `method` [#](#M-AutoPrintr-Job-Processing 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Processing"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-quantity'></a>
### quantity() `method` [#](#M-AutoPrintr-Job-quantity 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get quantity for this job

##### Returns



##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-Skipped-System-Int32-'></a>
### Skipped() `method` [#](#M-AutoPrintr-Job-Skipped-System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set job state "Ignored"

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Job-ToString'></a>
### ToString() `method` [#](#M-AutoPrintr-Job-ToString 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converting job to string

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-JobMsg'></a>
## JobMsg [#](#T-AutoPrintr-JobMsg 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Job msg class. This class is used for parsing JSON.

<a name='T-AutoPrintr-Jobs'></a>
## Jobs [#](#T-AutoPrintr-Jobs 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

General jobs actions

<a name='F-AutoPrintr-Jobs-list'></a>
### list `constants` [#](#F-AutoPrintr-Jobs-list 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Jobs list

<a name='F-AutoPrintr-Jobs-newJobEvent'></a>
### newJobEvent `constants` [#](#F-AutoPrintr-Jobs-newJobEvent 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Constant with new print job event name from Pusher

<a name='M-AutoPrintr-Jobs-init-System-String,System-Action{System-Exception,AutoPrintr-Job}-'></a>
### init(channel,onJob) `method` [#](#M-AutoPrintr-Jobs-init-System-String,System-Action{System-Exception,AutoPrintr-Job}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Job listener

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| channel | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| onJob | [System.Action{System.Exception,AutoPrintr.Job}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Exception,AutoPrintr.Job}') |  |

<a name='M-AutoPrintr-Jobs-msgValidate-System-Object-'></a>
### msgValidate(msg) `method` [#](#M-AutoPrintr-Jobs-msgValidate-System-Object- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Pusher msg validation

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| msg | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | parsed msg object from pusher |

<a name='T-AutoPrintr-Jobs-JobsList'></a>
## JobsList [#](#T-AutoPrintr-Jobs-JobsList 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Jobs

##### Summary

Class for jobs list operating: it shall be mapped to file also

<a name='T-AutoPrintr-JobsList'></a>
## JobsList [#](#T-AutoPrintr-JobsList 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Jobs list UI control

<a name='M-AutoPrintr-JobsList-#ctor'></a>
### #ctor() `constructor` [#](#M-AutoPrintr-JobsList-#ctor 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new jobs list

##### Parameters

This constructor has no parameters.

<a name='F-AutoPrintr-JobsList-components'></a>
### components `constants` [#](#F-AutoPrintr-JobsList-components 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Требуется переменная конструктора.

<a name='F-AutoPrintr-JobsList-headerItems'></a>
### headerItems `constants` [#](#F-AutoPrintr-JobsList-headerItems 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

List of jobs table header items

<a name='F-AutoPrintr-JobsList-items'></a>
### items `constants` [#](#F-AutoPrintr-JobsList-items 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

JobsList job list

<a name='M-AutoPrintr-JobsList-add-AutoPrintr-Job-'></a>
### add(job) `method` [#](#M-AutoPrintr-JobsList-add-AutoPrintr-Job- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Add job to UI

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| job | [AutoPrintr.Job](#T-AutoPrintr-Job 'AutoPrintr.Job') |  |

<a name='M-AutoPrintr-JobsList-addColumn-System-String-'></a>
### addColumn(name) `method` [#](#M-AutoPrintr-JobsList-addColumn-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Add column with selected name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-JobsList-addJobControls-AutoPrintr-JobsList-UIJob-'></a>
### addJobControls(uiJob) `method` [#](#M-AutoPrintr-JobsList-addJobControls-AutoPrintr-JobsList-UIJob- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Add controls for job

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uiJob | [AutoPrintr.JobsList.UIJob](#T-AutoPrintr-JobsList-UIJob 'AutoPrintr.JobsList.UIJob') |  |

<a name='M-AutoPrintr-JobsList-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method` [#](#M-AutoPrintr-JobsList-Dispose-System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Освободить все используемые ресурсы.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | истинно, если управляемый ресурс должен быть удален; иначе ложно. |

<a name='M-AutoPrintr-JobsList-InitializeComponent'></a>
### InitializeComponent() `method` [#](#M-AutoPrintr-JobsList-InitializeComponent 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Обязательный метод для поддержки конструктора - не изменяйте содержимое данного метода при помощи редактора кода.

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-JobsList-update-AutoPrintr-JobsList-UIJob,AutoPrintr-Job-'></a>
### update(uiJob,j) `method` [#](#M-AutoPrintr-JobsList-update-AutoPrintr-JobsList-UIJob,AutoPrintr-Job- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Update job in UI

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uiJob | [AutoPrintr.JobsList.UIJob](#T-AutoPrintr-JobsList-UIJob 'AutoPrintr.JobsList.UIJob') |  |
| j | [AutoPrintr.Job](#T-AutoPrintr-Job 'AutoPrintr.Job') |  |

<a name='T-AutoPrintr-JobsList-JobsListLabel'></a>
## JobsListLabel [#](#T-AutoPrintr-JobsList-JobsListLabel 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.JobsList

##### Summary

Label in JobsList

<a name='M-AutoPrintr-JobsList-JobsListLabel-#ctor-System-String-'></a>
### #ctor(text) `constructor` [#](#M-AutoPrintr-JobsList-JobsListLabel-#ctor-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new label for jobs list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-JobsServer'></a>
## JobsServer [#](#T-AutoPrintr-JobsServer 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Server with API for requesting new print jobs

<a name='F-AutoPrintr-JobsServer-channels'></a>
### channels `constants` [#](#F-AutoPrintr-JobsServer-channels 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

List of channels

<a name='F-AutoPrintr-JobsServer-pusher'></a>
### pusher `constants` [#](#F-AutoPrintr-JobsServer-pusher 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Pusher instance

<a name='F-AutoPrintr-JobsServer-state'></a>
### state `constants` [#](#F-AutoPrintr-JobsServer-state 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Pusher current connection state

<a name='M-AutoPrintr-JobsServer-connect-System-Collections-Generic-List{AutoPrintr-Listener},System-Action{PusherClient-PusherException},System-Action{System-String}-'></a>
### connect(listeners,onError,onStateChanged) `method` [#](#M-AutoPrintr-JobsServer-connect-System-Collections-Generic-List{AutoPrintr-Listener},System-Action{PusherClient-PusherException},System-Action{System-String}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Connect to jobs server

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| listeners | [System.Collections.Generic.List{AutoPrintr.Listener}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{AutoPrintr.Listener}') |  |
| onError | [System.Action{PusherClient.PusherException}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{PusherClient.PusherException}') |  |
| onStateChanged | [System.Action{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.String}') |  |

<a name='T-AutoPrintr-JobState'></a>
## JobState [#](#T-AutoPrintr-JobState 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Job state constants

<a name='T-AutoPrintr-Listener'></a>
## Listener [#](#T-AutoPrintr-Listener 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Pusher channel listener

<a name='M-AutoPrintr-Listener-#ctor-System-String,System-String,System-Action{System-Object}-'></a>
### #ctor(channel,evt,onMessage) `constructor` [#](#M-AutoPrintr-Listener-#ctor-System-String,System-String,System-Action{System-Object}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new listener for channel and event

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| channel | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| evt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| onMessage | [System.Action{System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{System.Object}') |  |

<a name='F-AutoPrintr-Listener-channel'></a>
### channel `constants` [#](#F-AutoPrintr-Listener-channel 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Listener channel string id

<a name='F-AutoPrintr-Listener-evt'></a>
### evt `constants` [#](#F-AutoPrintr-Listener-evt 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Listener event string

<a name='F-AutoPrintr-Listener-onMessage'></a>
### onMessage `constants` [#](#F-AutoPrintr-Listener-onMessage 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Listener action for message from pusher

<a name='T-AutoPrintr-LogConfig'></a>
## LogConfig [#](#T-AutoPrintr-LogConfig 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Log configuration class

<a name='F-AutoPrintr-LogConfig-logConfigFile'></a>
### logConfigFile `constants` [#](#F-AutoPrintr-LogConfig-logConfigFile 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Log configuration file (NLog)

<a name='F-AutoPrintr-LogConfig-LogLevels'></a>
### LogLevels `constants` [#](#F-AutoPrintr-LogConfig-LogLevels 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

LOg levels list

<a name='F-AutoPrintr-LogConfig-NLog2UserLogName'></a>
### NLog2UserLogName `constants` [#](#F-AutoPrintr-LogConfig-NLog2UserLogName 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converter for log levels

<a name='F-AutoPrintr-LogConfig-UserLogName2NLog'></a>
### UserLogName2NLog `constants` [#](#F-AutoPrintr-LogConfig-UserLogName2NLog 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converter for log levels

<a name='M-AutoPrintr-LogConfig-logLevel-System-String-'></a>
### logLevel(level) `method` [#](#M-AutoPrintr-LogConfig-logLevel-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set log level

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| level | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-LoginResponse'></a>
## LoginResponse [#](#T-AutoPrintr-LoginResponse 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Login server response class for parsing JSON

<a name='T-AutoPrintr-LoginServer'></a>
## LoginServer [#](#T-AutoPrintr-LoginServer 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Login server class

<a name='F-AutoPrintr-LoginServer-channel'></a>
### channel `constants` [#](#F-AutoPrintr-LoginServer-channel 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

User channel for pusher API

<a name='F-AutoPrintr-LoginServer-defaultLocation'></a>
### defaultLocation `constants` [#](#F-AutoPrintr-LoginServer-defaultLocation 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

User default location

<a name='F-AutoPrintr-LoginServer-domain'></a>
### domain `constants` [#](#F-AutoPrintr-LoginServer-domain 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

User domain - require fro API access

<a name='F-AutoPrintr-LoginServer-isMultiLocations'></a>
### isMultiLocations `constants` [#](#F-AutoPrintr-LoginServer-isMultiLocations 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Multi/single locations flag

<a name='F-AutoPrintr-LoginServer-locationID2String'></a>
### locationID2String `constants` [#](#F-AutoPrintr-LoginServer-locationID2String 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary-converter for convertin location ID to string

<a name='F-AutoPrintr-LoginServer-locations'></a>
### locations `constants` [#](#F-AutoPrintr-LoginServer-locations 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Array with available user locations

<a name='F-AutoPrintr-LoginServer-locationString2ID'></a>
### locationString2ID `constants` [#](#F-AutoPrintr-LoginServer-locationString2ID 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary-converter for convertin location string to ID

<a name='F-AutoPrintr-LoginServer-registers'></a>
### registers `constants` [#](#F-AutoPrintr-LoginServer-registers 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Registers collection

<a name='F-AutoPrintr-LoginServer-serverUrl'></a>
### serverUrl `constants` [#](#F-AutoPrintr-LoginServer-serverUrl 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Url for sign in

<a name='F-AutoPrintr-LoginServer-UserToken'></a>
### UserToken `constants` [#](#F-AutoPrintr-LoginServer-UserToken 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

User token from server for API acess

<a name='M-AutoPrintr-LoginServer-getSettings-System-String,System-String,System-String-'></a>
### getSettings(domain,host,xt) `method` [#](#M-AutoPrintr-LoginServer-getSettings-System-String,System-String,System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Request to login server for pucher user channel ID

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| domain | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| host | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| xt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-LoginServer-login-System-String,System-String-'></a>
### login(username,password) `method` [#](#M-AutoPrintr-LoginServer-login-System-String,System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Method for login via username and password

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-tools-logLevels'></a>
## logLevels [#](#T-AutoPrintr-tools-logLevels 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.tools

##### Summary

Log levels of NLog

<a name='F-AutoPrintr-tools-logLevels-Debug'></a>
### Debug `constants` [#](#F-AutoPrintr-tools-logLevels-Debug 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Debug log level

<a name='F-AutoPrintr-tools-logLevels-Error'></a>
### Error `constants` [#](#F-AutoPrintr-tools-logLevels-Error 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Error log level

<a name='F-AutoPrintr-tools-logLevels-Fatal'></a>
### Fatal `constants` [#](#F-AutoPrintr-tools-logLevels-Fatal 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Fatal log level

<a name='F-AutoPrintr-tools-logLevels-Info'></a>
### Info `constants` [#](#F-AutoPrintr-tools-logLevels-Info 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Info log level

<a name='F-AutoPrintr-tools-logLevels-Trace'></a>
### Trace `constants` [#](#F-AutoPrintr-tools-logLevels-Trace 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Trace log level

<a name='F-AutoPrintr-tools-logLevels-Warn'></a>
### Warn `constants` [#](#F-AutoPrintr-tools-logLevels-Warn 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Warning log level

<a name='T-AutoPrintr-LogWatcher'></a>
## LogWatcher [#](#T-AutoPrintr-LogWatcher 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Log watching class

<a name='F-AutoPrintr-LogWatcher-file'></a>
### file `constants` [#](#F-AutoPrintr-LogWatcher-file 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Log file name, shall be same as in NLog.config

<a name='T-AutoPrintr-mainWin'></a>
## mainWin [#](#T-AutoPrintr-mainWin 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Main window class

<a name='M-AutoPrintr-mainWin-#ctor'></a>
### #ctor() `constructor` [#](#M-AutoPrintr-mainWin-#ctor 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create main window form

##### Parameters

This constructor has no parameters.

<a name='F-AutoPrintr-mainWin-components'></a>
### components `constants` [#](#F-AutoPrintr-mainWin-components 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Требуется переменная конструктора.

<a name='F-AutoPrintr-mainWin-registersDD'></a>
### registersDD `constants` [#](#F-AutoPrintr-mainWin-registersDD 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

List of dropdowns with registers

<a name='M-AutoPrintr-mainWin-aboutTabInit'></a>
### aboutTabInit() `method` [#](#M-AutoPrintr-mainWin-aboutTabInit 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

About tab initialization

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-configTabInit'></a>
### configTabInit() `method` [#](#M-AutoPrintr-mainWin-configTabInit 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Configuration tab initialization

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-createPrintersUI'></a>
### createPrintersUI() `method` [#](#M-AutoPrintr-mainWin-createPrintersUI 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Generate printers UI

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method` [#](#M-AutoPrintr-mainWin-Dispose-System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Освободить все используемые ресурсы.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | истинно, если управляемый ресурс должен быть удален; иначе ложно. |

<a name='M-AutoPrintr-mainWin-getLicenseText'></a>
### getLicenseText() `method` [#](#M-AutoPrintr-mainWin-getLicenseText 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Return license text

##### Returns

License string

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-helpButton_Click-System-Object,System-EventArgs-'></a>
### helpButton_Click(sender,e) `method` [#](#M-AutoPrintr-mainWin-helpButton_Click-System-Object,System-EventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Help button handler

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-AutoPrintr-mainWin-InitializeComponent'></a>
### InitializeComponent() `method` [#](#M-AutoPrintr-mainWin-InitializeComponent 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Обязательный метод для поддержки конструктора - не изменяйте содержимое данного метода при помощи редактора кода.

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-logTabInit'></a>
### logTabInit() `method` [#](#M-AutoPrintr-mainWin-logTabInit 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Log tab initialization

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-mainWin_Resize-System-Object,System-EventArgs-'></a>
### mainWin_Resize(sender,e) `method` [#](#M-AutoPrintr-mainWin-mainWin_Resize-System-Object,System-EventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Minimize application to tray icon

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-AutoPrintr-mainWin-onLogChange-System-Object,System-EventArgs-'></a>
### onLogChange(o,e) `method` [#](#M-AutoPrintr-mainWin-onLogChange-System-Object,System-EventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Evevent handler for log change event

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-AutoPrintr-mainWin-setStatus-System-String-'></a>
### setStatus(str) `method` [#](#M-AutoPrintr-mainWin-setStatus-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set status string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-mainWin-srvConnect-System-String-'></a>
### srvConnect() `method` [#](#M-AutoPrintr-mainWin-srvConnect-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Server connect

##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-mainWin-submit_Click-System-Object,System-EventArgs-'></a>
### submit_Click(sender,ev) `method` [#](#M-AutoPrintr-mainWin-submit_Click-System-Object,System-EventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Login button handler

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| ev | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='M-AutoPrintr-mainWin-updateLocations-System-Collections-Generic-List{AutoPrintr-Location},AutoPrintr-Location-'></a>
### updateLocations(locations,defaultLocation) `method` [#](#M-AutoPrintr-mainWin-updateLocations-System-Collections-Generic-List{AutoPrintr-Location},AutoPrintr-Location- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Render locations

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| locations | [System.Collections.Generic.List{AutoPrintr.Location}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{AutoPrintr.Location}') |  |
| defaultLocation | [AutoPrintr.Location](#T-AutoPrintr-Location 'AutoPrintr.Location') |  |

<a name='T-AutoPrintr-pLabel'></a>
## pLabel [#](#T-AutoPrintr-pLabel 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Printer label

<a name='T-AutoPrintr-PrintEngine-printDelegate'></a>
## printDelegate [#](#T-AutoPrintr-PrintEngine-printDelegate 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.PrintEngine

##### Summary

Print delegete type (not action, because delegate support named parameters and VS can show this parameters as documentation)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| printerName | [T:AutoPrintr.PrintEngine.printDelegate](#T-T-AutoPrintr-PrintEngine-printDelegate 'T:AutoPrintr.PrintEngine.printDelegate') |  |

<a name='T-AutoPrintr-PrintEngine'></a>
## PrintEngine [#](#T-AutoPrintr-PrintEngine 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Print engine class

<a name='M-AutoPrintr-PrintEngine-#ctor-System-String,AutoPrintr-PrintEngine-printDelegate-'></a>
### #ctor(name,printAction) `constructor` [#](#M-AutoPrintr-PrintEngine-#ctor-System-String,AutoPrintr-PrintEngine-printDelegate- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new PrintEngine with selected name and printAction

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| printAction | [AutoPrintr.PrintEngine.printDelegate](#T-AutoPrintr-PrintEngine-printDelegate 'AutoPrintr.PrintEngine.printDelegate') |  |

<a name='F-AutoPrintr-PrintEngine-name'></a>
### name `constants` [#](#F-AutoPrintr-PrintEngine-name 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Engine name

<a name='F-AutoPrintr-PrintEngine-print'></a>
### print `constants` [#](#F-AutoPrintr-PrintEngine-print 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print method for engine

<a name='M-AutoPrintr-PrintEngine-ToString'></a>
### ToString() `method` [#](#M-AutoPrintr-PrintEngine-ToString 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Converts engine instance to string - name.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-PrintEngineDD'></a>
## PrintEngineDD [#](#T-AutoPrintr-PrintEngineDD 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Custom combo box for selecting print engine for printer

<a name='M-AutoPrintr-PrintEngineDD-#ctor-AutoPrintr-Printer-'></a>
### #ctor(printer) `constructor` [#](#M-AutoPrintr-PrintEngineDD-#ctor-AutoPrintr-Printer- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new combo box for selected printer

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| printer | [AutoPrintr.Printer](#T-AutoPrintr-Printer 'AutoPrintr.Printer') |  |

<a name='F-AutoPrintr-PrintEngineDD-printer'></a>
### printer `constants` [#](#F-AutoPrintr-PrintEngineDD-printer 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Printer for this combo box

<a name='M-AutoPrintr-PrintEngineDD-PrintEngineDD_TextChanged-System-Object,System-EventArgs-'></a>
### PrintEngineDD_TextChanged(sender,e) `method` [#](#M-AutoPrintr-PrintEngineDD-PrintEngineDD_TextChanged-System-Object,System-EventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print engine combo box change event handler

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='T-AutoPrintr-PrintEngines'></a>
## PrintEngines [#](#T-AutoPrintr-PrintEngines 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Print engines manager classs

<a name='F-AutoPrintr-PrintEngines-AcrobatReader'></a>
### AcrobatReader `constants` [#](#F-AutoPrintr-PrintEngines-AcrobatReader 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print via external programm Acrobat Reader

<a name='F-AutoPrintr-PrintEngines-Default'></a>
### Default `constants` [#](#F-AutoPrintr-PrintEngines-Default 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Default print engine

<a name='F-AutoPrintr-PrintEngines-DefaultPdfReader'></a>
### DefaultPdfReader `constants` [#](#F-AutoPrintr-PrintEngines-DefaultPdfReader 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print via default system PDF reader

<a name='F-AutoPrintr-PrintEngines-list'></a>
### list `constants` [#](#F-AutoPrintr-PrintEngines-list 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Dictionary for converting engine name to engine instance

<a name='F-AutoPrintr-PrintEngines-SumatraPDF'></a>
### SumatraPDF `constants` [#](#F-AutoPrintr-PrintEngines-SumatraPDF 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print via external programm Sumatra PDF

<a name='M-AutoPrintr-PrintEngines-find-System-String-'></a>
### find(engineName) `method` [#](#M-AutoPrintr-PrintEngines-find-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Find print engine by name

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| engineName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-AutoPrintr-Printer'></a>
## Printer [#](#T-AutoPrintr-Printer 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

<a name='M-AutoPrintr-Printer-#ctor-System-String,System-Collections-Generic-List{AutoPrintr-DocType}-'></a>
### #ctor(name,types,r,l) `constructor` [#](#M-AutoPrintr-Printer-#ctor-System-String,System-Collections-Generic-List{AutoPrintr-DocType}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new printer

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Name |
| types | [System.Collections.Generic.List{AutoPrintr.DocType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{AutoPrintr.DocType}') | Types states |

<a name='M-AutoPrintr-Printer-print-System-String,System-String,System-String-'></a>
### print(filePath,documentName) `method` [#](#M-AutoPrintr-Printer-print-System-String,System-String,System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Print file

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filePath | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| documentName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-Printer-ToString'></a>
### ToString() `method` [#](#M-AutoPrintr-Printer-ToString 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Printer to string

##### Returns



##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Printer-triggerGet-AutoPrintr-DocType-'></a>
### triggerGet(type) `method` [#](#M-AutoPrintr-Printer-triggerGet-AutoPrintr-DocType- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get trigger state

##### Returns

value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [AutoPrintr.DocType](#T-AutoPrintr-DocType 'AutoPrintr.DocType') |  |

<a name='M-AutoPrintr-Printer-triggerSet-AutoPrintr-DocType,System-Boolean-'></a>
### triggerSet(type,val) `method` [#](#M-AutoPrintr-Printer-triggerSet-AutoPrintr-DocType,System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set trigger type state

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [AutoPrintr.DocType](#T-AutoPrintr-DocType 'AutoPrintr.DocType') | Document type |
| val | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Value |

<a name='M-AutoPrintr-Printer-typeGet-AutoPrintr-DocType-'></a>
### typeGet(type) `method` [#](#M-AutoPrintr-Printer-typeGet-AutoPrintr-DocType- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get printing type state

##### Returns

value

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [AutoPrintr.DocType](#T-AutoPrintr-DocType 'AutoPrintr.DocType') |  |

<a name='M-AutoPrintr-Printer-typeSet-AutoPrintr-DocType,System-Boolean-'></a>
### typeSet(type,val) `method` [#](#M-AutoPrintr-Printer-typeSet-AutoPrintr-DocType,System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Set printing type state

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [AutoPrintr.DocType](#T-AutoPrintr-DocType 'AutoPrintr.DocType') | Document type |
| val | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Value |

<a name='T-AutoPrintr-PrinterDocumentControl'></a>
## PrinterDocumentControl [#](#T-AutoPrintr-PrinterDocumentControl 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

<a name='F-AutoPrintr-PrinterDocumentControl-components'></a>
### components `constants` [#](#F-AutoPrintr-PrinterDocumentControl-components 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Требуется переменная конструктора.

<a name='M-AutoPrintr-PrinterDocumentControl-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method` [#](#M-AutoPrintr-PrinterDocumentControl-Dispose-System-Boolean- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Освободить все используемые ресурсы.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | истинно, если управляемый ресурс должен быть удален; иначе ложно. |

<a name='M-AutoPrintr-PrinterDocumentControl-InitializeComponent'></a>
### InitializeComponent() `method` [#](#M-AutoPrintr-PrinterDocumentControl-InitializeComponent 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Обязательный метод для поддержки конструктора - не изменяйте содержимое данного метода при помощи редактора кода.

##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-Printers'></a>
## Printers [#](#T-AutoPrintr-Printers 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Static class for printers management

<a name='M-AutoPrintr-Printers-findPrinters-System-String,System-Int32,System-Int32-'></a>
### findPrinters(type,location,register) `method` [#](#M-AutoPrintr-Printers-findPrinters-System-String,System-Int32,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Find printers for this types and location

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| location | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| register | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-AutoPrintr-Printers-get'></a>
### get() `method` [#](#M-AutoPrintr-Printers-get 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Find existing system printers and merge it with saved in config printers list

##### Returns



##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-Printers-init'></a>
### init() `method` [#](#M-AutoPrintr-Printers-init 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Intialization of printers static class

##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-Program'></a>
## Program [#](#T-AutoPrintr-Program 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Main class

<a name='F-AutoPrintr-Program-appInitString'></a>
### appInitString `constants` [#](#F-AutoPrintr-Program-appInitString 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Application start log marker

<a name='F-AutoPrintr-Program-config'></a>
### config `constants` [#](#F-AutoPrintr-Program-config 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Application configuration

<a name='F-AutoPrintr-Program-tempDir'></a>
### tempDir `constants` [#](#F-AutoPrintr-Program-tempDir 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Temporary directory

<a name='F-AutoPrintr-Program-tempDnDir'></a>
### tempDnDir `constants` [#](#F-AutoPrintr-Program-tempDnDir 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Temporary directory for fiels download

<a name='F-AutoPrintr-Program-window'></a>
### window `constants` [#](#F-AutoPrintr-Program-window 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Main applciation window

<a name='M-AutoPrintr-Program-Main-System-String[]-'></a>
### Main() `method` [#](#M-AutoPrintr-Program-Main-System-String[]- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Main entry point

##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-LoginServer-Register'></a>
## Register [#](#T-AutoPrintr-LoginServer-Register 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.LoginServer

##### Summary

Register class api/v1/settings/printing

<a name='T-AutoPrintr-RegisterDD'></a>
## RegisterDD [#](#T-AutoPrintr-RegisterDD 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Custom combo box for selecting register associated with printer

<a name='M-AutoPrintr-RegisterDD-#ctor-AutoPrintr-Printer,System-Collections-Generic-List{AutoPrintr-LoginServer-Register}-'></a>
### #ctor(printer) `constructor` [#](#M-AutoPrintr-RegisterDD-#ctor-AutoPrintr-Printer,System-Collections-Generic-List{AutoPrintr-LoginServer-Register}- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new combo box for selected printer

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| printer | [AutoPrintr.Printer](#T-AutoPrintr-Printer 'AutoPrintr.Printer') |  |

<a name='F-AutoPrintr-RegisterDD-printer'></a>
### printer `constants` [#](#F-AutoPrintr-RegisterDD-printer 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Printer for this combo box

<a name='M-AutoPrintr-RegisterDD-RegisterDD_TextChanged-System-Object,System-EventArgs-'></a>
### RegisterDD_TextChanged(sender,e) `method` [#](#M-AutoPrintr-RegisterDD-RegisterDD_TextChanged-System-Object,System-EventArgs- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Combo box change event handler

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.EventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.EventArgs 'System.EventArgs') |  |

<a name='T-AutoPrintr-Properties-Resources'></a>
## Resources [#](#T-AutoPrintr-Properties-Resources 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Properties

##### Summary

Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.

<a name='P-AutoPrintr-Properties-Resources-Culture'></a>
### Culture `property` [#](#P-AutoPrintr-Properties-Resources-Culture 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Перезаписывает свойство CurrentUICulture текущего потока для всех обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.

<a name='P-AutoPrintr-Properties-Resources-ResourceManager'></a>
### ResourceManager `property` [#](#P-AutoPrintr-Properties-Resources-ResourceManager 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.

<a name='T-AutoPrintr-mainWin-setStatusCb'></a>
## setStatusCb [#](#T-AutoPrintr-mainWin-setStatusCb 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.mainWin

##### Summary

Delegate for settin status string

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| str | [T:AutoPrintr.mainWin.setStatusCb](#T-T-AutoPrintr-mainWin-setStatusCb 'T:AutoPrintr.mainWin.setStatusCb') |  |

<a name='T-AutoPrintr-Settings'></a>
## Settings [#](#T-AutoPrintr-Settings 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Application settings structure

<a name='F-AutoPrintr-Settings-availableLocations'></a>
### availableLocations `constants` [#](#F-AutoPrintr-Settings-availableLocations 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Selected locations

<a name='F-AutoPrintr-Settings-channel'></a>
### channel `constants` [#](#F-AutoPrintr-Settings-channel 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

User's channel ID

<a name='F-AutoPrintr-Settings-locations'></a>
### locations `constants` [#](#F-AutoPrintr-Settings-locations 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Selected locations

<a name='F-AutoPrintr-Settings-login'></a>
### login `constants` [#](#F-AutoPrintr-Settings-login 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

User's login

<a name='F-AutoPrintr-Settings-printers'></a>
### printers `constants` [#](#F-AutoPrintr-Settings-printers 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Printers configurations

<a name='F-AutoPrintr-Settings-registers'></a>
### registers `constants` [#](#F-AutoPrintr-Settings-registers 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Registers list

<a name='T-AutoPrintr-Skins-Skin'></a>
## Skin [#](#T-AutoPrintr-Skins-Skin 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Skins

##### Summary

Base skin class

<a name='M-AutoPrintr-Skins-Skin-apply-System-Windows-Forms-Control-'></a>
### apply(control) `method` [#](#M-AutoPrintr-Skins-Skin-apply-System-Windows-Forms-Control- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Apply this skin to control

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| control | [System.Windows.Forms.Control](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Control 'System.Windows.Forms.Control') |  |

<a name='T-AutoPrintr-Skins-SkinCheckBox'></a>
## SkinCheckBox [#](#T-AutoPrintr-Skins-SkinCheckBox 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Skins

##### Summary

Skin for custom checkboxes

<a name='T-AutoPrintr-Skins-SkinConfig'></a>
## SkinConfig [#](#T-AutoPrintr-Skins-SkinConfig 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Skins

##### Summary

Skin configuration

<a name='T-AutoPrintr-Skins-skinFont'></a>
## skinFont [#](#T-AutoPrintr-Skins-skinFont 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Skins

##### Summary

Skin font

<a name='T-AutoPrintr-Skins-SkinForControl'></a>
## SkinForControl [#](#T-AutoPrintr-Skins-SkinForControl 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.Skins

##### Summary

Skin class for processing items by name and type

<a name='M-AutoPrintr-Skins-SkinForControl-apply-System-Windows-Forms-Control-'></a>
### apply(control) `method` [#](#M-AutoPrintr-Skins-SkinForControl-apply-System-Windows-Forms-Control- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Apply this skin to control

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| control | [System.Windows.Forms.Control](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Control 'System.Windows.Forms.Control') |  |

<a name='T-AutoPrintr-Skins'></a>
## Skins [#](#T-AutoPrintr-Skins 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

<a name='F-AutoPrintr-Skins-config'></a>
### config `constants` [#](#F-AutoPrintr-Skins-config 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Current skin configuration

<a name='F-AutoPrintr-Skins-file'></a>
### file `constants` [#](#F-AutoPrintr-Skins-file 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Skin configuration file

<a name='F-AutoPrintr-Skins-fileExample'></a>
### fileExample `constants` [#](#F-AutoPrintr-Skins-fileExample 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Skin configuration file

<a name='T-AutoPrintr-tabelLabel'></a>
## tabelLabel [#](#T-AutoPrintr-tabelLabel 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Label for porinters table

<a name='T-AutoPrintr-tools'></a>
## tools [#](#T-AutoPrintr-tools 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Various usefull tools

<a name='F-AutoPrintr-tools-shortVersion'></a>
### shortVersion `constants` [#](#F-AutoPrintr-tools-shortVersion 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Application short string version

<a name='F-AutoPrintr-tools-version'></a>
### version `constants` [#](#F-AutoPrintr-tools-version 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Application full version

<a name='M-AutoPrintr-tools-BytesToString-System-Int64-'></a>
### BytesToString(byteCount) `method` [#](#M-AutoPrintr-tools-BytesToString-System-Int64- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert number of bytes to formatted string

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| byteCount | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') |  |

<a name='M-AutoPrintr-tools-Color2RGB-System-Drawing-Color-'></a>
### Color2RGB(c) `method` [#](#M-AutoPrintr-tools-Color2RGB-System-Drawing-Color- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert color to RGB string

##### Returns

Hex string color

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| c | [System.Drawing.Color](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Drawing.Color 'System.Drawing.Color') | Color |

<a name='M-AutoPrintr-tools-DirEmpty-System-String-'></a>
### DirEmpty(path) `method` [#](#M-AutoPrintr-tools-DirEmpty-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Remove all fiels from directory

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-tools-GET-System-String-'></a>
### GET(Url) `method` [#](#M-AutoPrintr-tools-GET-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get request to url

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Url | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AutoPrintr-tools-GetAllControls-System-Windows-Forms-Control-'></a>
### GetAllControls(container) `method` [#](#M-AutoPrintr-tools-GetAllControls-System-Windows-Forms-Control- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Get all UI controls

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [System.Windows.Forms.Control](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Control 'System.Windows.Forms.Control') |  |

<a name='M-AutoPrintr-tools-randomFileName'></a>
### randomFileName() `method` [#](#M-AutoPrintr-tools-randomFileName 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Generate random file name

##### Returns



##### Parameters

This method has no parameters.

<a name='M-AutoPrintr-tools-RGB2Color-System-String-'></a>
### RGB2Color(s) `method` [#](#M-AutoPrintr-tools-RGB2Color-System-String- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Convert RGB string to color

##### Returns

Color

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| s | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Hex string color |

<a name='M-AutoPrintr-tools-SetAllowUnsafeHeaderParsing20'></a>
### SetAllowUnsafeHeaderParsing20() `method` [#](#M-AutoPrintr-tools-SetAllowUnsafeHeaderParsing20 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Disable error trowing on http errors in Net module

##### Returns



##### Parameters

This method has no parameters.

<a name='T-AutoPrintr-TriggerCheckBox'></a>
## TriggerCheckBox [#](#T-AutoPrintr-TriggerCheckBox 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Printer trigger checkbox

<a name='F-AutoPrintr-TriggerCheckBox-docType'></a>
### docType `constants` [#](#F-AutoPrintr-TriggerCheckBox-docType 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

DocType

<a name='F-AutoPrintr-TriggerCheckBox-printer'></a>
### printer `constants` [#](#F-AutoPrintr-TriggerCheckBox-printer 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Printer

<a name='F-AutoPrintr-TriggerCheckBox-ttText'></a>
### ttText `constants` [#](#F-AutoPrintr-TriggerCheckBox-ttText 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Tool tip text

<a name='T-AutoPrintr-JobsList-UIJob'></a>
## UIJob [#](#T-AutoPrintr-JobsList-UIJob 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.JobsList

##### Summary

UI job class

<a name='M-AutoPrintr-JobsList-UIJob-#ctor-AutoPrintr-Job,System-Int32,System-Int32-'></a>
### #ctor(job,row,index) `constructor` [#](#M-AutoPrintr-JobsList-UIJob-#ctor-AutoPrintr-Job,System-Int32,System-Int32- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Create new UI job instance

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| job | [AutoPrintr.Job](#T-AutoPrintr-Job 'AutoPrintr.Job') |  |
| row | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

<a name='M-AutoPrintr-JobsList-UIJob-update-AutoPrintr-Job-'></a>
### update(job) `method` [#](#M-AutoPrintr-JobsList-UIJob-update-AutoPrintr-Job- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Update job in UI

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| job | [AutoPrintr.Job](#T-AutoPrintr-Job 'AutoPrintr.Job') |  |

<a name='T-AutoPrintr-JobsList-updateCb'></a>
## updateCb [#](#T-AutoPrintr-JobsList-updateCb 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr.JobsList

##### Summary

Delegate for updating job in UI

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uiJob | [T:AutoPrintr.JobsList.updateCb](#T-T-AutoPrintr-JobsList-updateCb 'T:AutoPrintr.JobsList.updateCb') |  |

<a name='T-AutoPrintr-WinAutoSize'></a>
## WinAutoSize [#](#T-AutoPrintr-WinAutoSize 'Go To Here') [=](#contents 'Back To Contents')

##### Namespace

AutoPrintr

##### Summary

Window resizer

<a name='M-AutoPrintr-WinAutoSize-apply-AutoPrintr-mainWin,System-Windows-Forms-Control[]-'></a>
### apply(win,controls) `method` [#](#M-AutoPrintr-WinAutoSize-apply-AutoPrintr-mainWin,System-Windows-Forms-Control[]- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Resize window to fit content

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| win | [AutoPrintr.mainWin](#T-AutoPrintr-mainWin 'AutoPrintr.mainWin') |  |
| controls | [System.Windows.Forms.Control[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Control[] 'System.Windows.Forms.Control[]') |  |

<a name='M-AutoPrintr-WinAutoSize-getClientLocation-AutoPrintr-mainWin,System-Windows-Forms-Control-'></a>
### getClientLocation(win,control) `method` [#](#M-AutoPrintr-WinAutoSize-getClientLocation-AutoPrintr-mainWin,System-Windows-Forms-Control- 'Go To Here') [=](#contents 'Back To Contents')

##### Summary

Calculate client position of control in window

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| win | [AutoPrintr.mainWin](#T-AutoPrintr-mainWin 'AutoPrintr.mainWin') |  |
| control | [System.Windows.Forms.Control](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Forms.Control 'System.Windows.Forms.Control') |  |
