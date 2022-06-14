/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.Entities;
using QicFit.Entities;
using QicFit.Entities.System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QicFit.Services.Infrastructure
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetList(ContactFilter filter, ContextSession session);
    }
}
