﻿// Copyright 2011 Denis Markelov
// This code is distributed under Microsoft Public License 
// (for details please see \docs\Ms-PL)

#if ILSpy
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ICSharpCode.ILSpy;
using ICSharpCode.ILSpy.TreeNodes;
using ICSharpCode.TreeView;
using AssemblyVisualizer.Properties;
using AssemblyVisualizer.Model;
using AssemblyVisualizer.HAL;

namespace AssemblyVisualizer.AssemblyBrowser
{
    [ExportContextMenuEntry(Header = "Browse Assembly")]
	sealed class BrowseAssemblyContextMenuEntry : IContextMenuEntry
	{
        public bool IsVisible(TextViewContext context)
		{
			return context.SelectedTreeNodes.All(n => n is AssemblyTreeNode);
		}

        public bool IsEnabled(TextViewContext context)
		{
			return true;
		}

        public void Execute(TextViewContext context)
		{
			var assemblyDefinitions = context.SelectedTreeNodes
				.OfType<AssemblyTreeNode>()
				.Select(n => Converter.Assembly(n.LoadedAssembly.AssemblyDefinition))
				.ToList();

            Services.BrowseAssemblies(assemblyDefinitions);
		}
	}
}
#endif