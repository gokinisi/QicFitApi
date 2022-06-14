/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.Entities;

namespace QicFit.Entities.System
{
    public class ContactFilter : BaseFilter
    {
        public ContactFilter(string searchText = null, int pageNumber = 1, int pageSize = 10) : base(pageNumber, pageSize)
        {
            SearchText = searchText;
        }

        public string SearchText { get; set; }
    }
}
