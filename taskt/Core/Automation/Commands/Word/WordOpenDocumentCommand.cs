﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Word Commands")]
    [Attributes.ClassAttributes.Description("This command opens an Word Document.")]
    [Attributes.ClassAttributes.CommandSettings("Open Document")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to open an existing Word Document.")]
    [Attributes.ClassAttributes.ImplementationDescription("This command implements Word Interop to achieve automation.")]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public class WordOpenDocumentCommand : ScriptCommand
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(WordControls), nameof(WordControls.v_InstanceName))]
        public string v_InstanceName { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(WordControls), nameof(WordControls.v_FilePath))]
        public string v_FilePath { get; set; }

        public WordOpenDocumentCommand()
        {
            //this.CommandName = "WordOpenDocumentCommand";
            //this.SelectionName = "Open Document";
            //this.CommandEnabled = true;
            //this.CustomRendering = true;
        }

        public override void RunCommand(object sender)
        {
            var engine = (Engine.AutomationEngineInstance)sender;

            var wordInstance = v_InstanceName.GetWordInstance(engine);

            string vFilePath = FilePathControls.formatFilePath_NoFileCounter(v_FilePath, engine, new List<string>() { "docx", "docm", "doc", "odt", "rtf" }, true);
            wordInstance.Documents.Open(vFilePath);
        }
    }
}