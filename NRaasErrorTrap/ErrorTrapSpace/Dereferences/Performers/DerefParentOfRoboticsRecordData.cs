﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.TimeTravel;
using Sims3.Gameplay.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.ErrorTrapSpace.Dereferences
{
    public class DerefParentOfRoboticsRecordData : Dereference<ParentOfRoboticsRecordData>
    {
        protected override DereferenceResult Perform(ParentOfRoboticsRecordData reference, FieldInfo field, List<ReferenceWrapper> objects)
        {
            DereferenceResult reason = MatchAndRemove(reference, "mTraitChipsInstalledListener", field, ref reference.mTraitChipsInstalledListener, objects, DereferenceResult.End);
            if (reason != DereferenceResult.Failure)
            {
                return reason;
            }

            return DereferenceResult.Failure;
        }
    }
}
