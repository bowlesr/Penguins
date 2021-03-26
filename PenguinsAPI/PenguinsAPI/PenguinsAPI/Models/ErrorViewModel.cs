/*****************************************************************
 * Name:    ErrorViewModel.cs                                    *
 * By:      TeamPenguins                                         *
 * Purpose: Model Data for the Error View                        *
 ****************************************************************/
using System;

namespace PenguinsAPI.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);  //Only allows viewing Request if it exists, uses lambda expression
    }
}
