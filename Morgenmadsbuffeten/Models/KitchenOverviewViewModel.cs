using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Morgenmadsbuffeten.Data.DBModels;

namespace Morgenmadsbuffeten.Models
{
    public class KitchenOverviewViewModel
    {
        public KitchenOverviewViewModel(ExpectedGuests expectedGuestsInfo ,List<CheckedIn> checkedInEntries)
        {
            ExpectedGuests = expectedGuestsInfo;

            // Analyse data
            int adultsCheckedIn = 0;
            int childrenCheckedIn = 0;
            checkedInEntries.ForEach(c =>
            {
                adultsCheckedIn += c.NumberOfAdults;
                childrenCheckedIn += c.NumberOfChildren;
            });

            int totalCheckedIn = adultsCheckedIn + childrenCheckedIn;

            CheckedInAmount = new GuestAmount()
            {
                TotalAmount = totalCheckedIn,
                AdultsAmount = adultsCheckedIn,
                ChildrenAmount = childrenCheckedIn
            };
            NotCheckedInAmount = new GuestAmount()
            {
                TotalAmount = (expectedGuestsInfo.TotalAmount - totalCheckedIn),
                AdultsAmount = (expectedGuestsInfo.NumberOfAdults - adultsCheckedIn),
                ChildrenAmount = (expectedGuestsInfo.NumberOfChildren - childrenCheckedIn)
            };
        }

        public ExpectedGuests ExpectedGuests { get; set; }

        // Checked-in
        public GuestAmount CheckedInAmount { get; set; }

        // Not checked-in
        public GuestAmount NotCheckedInAmount { get; set; }


    }

    public class GuestAmount
    {
        [Display(Name = "Total")]
        public int TotalAmount { get; set; }
        [Display(Name = "Adults")]
        public int AdultsAmount { get; set; }
        [Display(Name = "Children")]
        public int ChildrenAmount { get; set; }
    }
}
