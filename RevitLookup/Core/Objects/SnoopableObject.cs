﻿// Copyright 2003-2023 by Autodesk, Inc.
// Copyright 2003-2023 by Autodesk, Inc.
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

using Autodesk.Revit.DB;
using RevitLookup.Core.Utils;

namespace RevitLookup.Core.Objects;

public sealed class SnoopableObject
{
    private IReadOnlyCollection<Descriptor> _members;

    public SnoopableObject(Type type)
    {
        Object = type;
        Descriptor = DescriptorUtils.FindSuitableDescriptor(type);
    }

    public SnoopableObject(Document context, object obj)
    {
        Object = obj;
        Context = context;
        Descriptor = DescriptorUtils.FindSuitableDescriptor(obj);
    }

    public object Object { get; set; }
    public Descriptor Descriptor { get; set; }
    public Document Context { get; }

    public IReadOnlyCollection<Descriptor> GetMembers()
    {
        return _members = new DescriptorBuilder(this).Build();
    }

    public async Task<IReadOnlyCollection<Descriptor>> GetMembersAsync()
    {
        return _members = await Application.ExternalDescriptorHandler.RaiseAsync(_ => new DescriptorBuilder(this).Build());
    }

    public async Task<IReadOnlyCollection<Descriptor>> GetCachedMembersAsync()
    {
        return _members ?? await GetMembersAsync();
    }
}