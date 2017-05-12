using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Analytics;
using Android.Support.V4.App;
using Android.Support.V4.View;
//using Android.Support.V7.App;
using Android.Util;
using System.Globalization;

namespace GooglePlayAnalyticsPoc
{
    public class GPAService
    {
        public string TrackingId = "UA-99080031-1";

        private static GoogleAnalytics GAInstance;
        private static Tracker GATracker;

        #region Instantiation ...
        private static GPAService thisRef;
        private GPAService()
        {
            // no code req'd
        }

        public static GPAService GetGASInstance()
        {
            if (thisRef == null)
                // it's ok, we can call this constructor
                thisRef = new GPAService();
            return thisRef;
        }
        #endregion

        public void Initialize(Context AppContext)
        {
            GAInstance = GoogleAnalytics.GetInstance(AppContext.ApplicationContext);
            GAInstance.SetLocalDispatchPeriod(10);

            GATracker = GAInstance.NewTracker(TrackingId);
            GATracker.EnableExceptionReporting(true);
            GATracker.EnableAdvertisingIdCollection(true);
            GATracker.EnableAutoActivityTracking(true);
        }

        public void Track_App_Page(String PageNameToTrack)
        {
            GATracker.SetScreenName(PageNameToTrack);
            GATracker.Send(new HitBuilders.ScreenViewBuilder().Build());
        }

        public void Track_App_Event(String GAEventCategory, String EventToTrack)
        {
            HitBuilders.EventBuilder builder = new HitBuilders.EventBuilder();
            builder.SetCategory(GAEventCategory);
            builder.SetAction(EventToTrack);
            builder.SetLabel("AppEvent");

            GATracker.Send(builder.Build());
        }

        public void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
        {
            HitBuilders.ExceptionBuilder builder = new HitBuilders.ExceptionBuilder();
            builder.SetDescription(ExceptionMessageToTrack);
            builder.SetFatal(isFatalException);

            GATracker.Send(builder.Build());
        }
    }
}