# FunWithConfigs
Project created to access configs of dll. There should exists just one App.config per application! Why, you should ask? Answer is simple: does dll plugin should decide which runtime environment should use? No, this answer should belong to application.
But what with our abstraction, plugin app?
The module/plugin (read: some dll) should create their own config which copies itself to compilation folder (use properties of file in visual studio, and check that it should copies itself), and it is not named App.config, but something.config. When you need to create some reference from diffrent project that config will also copies to output destination folder of dependent project.
How you should handle plugin configs? You should include in plugin configs custom sections which certain plugin knows how to handle, and you can include appsettings, which you can merge as Dictionary <string, string>.
