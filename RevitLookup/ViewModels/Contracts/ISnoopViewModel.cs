﻿// Copyright 2003-2023 by Autodesk, Inc.
// 
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
// 
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
// 
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.

using CommunityToolkit.Mvvm.Input;
using RevitLookup.Core.Objects;
using RevitLookup.Services.Contracts;

namespace RevitLookup.ViewModels.Contracts;

public interface ISnoopViewModel : ISnoopService
{
    IReadOnlyCollection<SnoopableObject> SnoopableObjects { get; }
    IReadOnlyCollection<Descriptor> SnoopableData { get; }
    IReadOnlyCollection<SnoopableObject> FilteredSnoopableObjects { get; set; }
    IReadOnlyCollection<Descriptor> FilteredSnoopableData { get; set; }
    IAsyncRelayCommand FetchMembersCommand { get; }
    IAsyncRelayCommand RefreshMembersCommand { get; }
    public string SearchText { get; set; }
    public SnoopableObject SelectedObject { get; set; }
    void Navigate(Descriptor selectedItem);
    event EventHandler TreeSourceChanged;
    event EventHandler SearchResultsChanged;
}