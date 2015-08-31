using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace RentMetrics
{
    /// <summary>
    /// Registry Helper
    /// </summary>
    public class Reg
    {
        static readonly String SECTION = "RentMetrics";
        static readonly String KEY_API = "APIKey";

        /// <summary>
        /// API Key
        /// </summary>
        public static String API
        {
            get { return GetSetting(KEY_API); }
            set { SaveSetting(KEY_API, value); }
        }

        static Boolean SaveSetting(String Key, String Value)
        {
            using (RegistryKey key1 = Application.UserAppDataRegistry.CreateSubKey(SECTION))
            {
                if (key1 == null)
                    return false;

                try { key1.SetValue(Key, Value); }
                catch { return false; }
            }

            return true;
        }

        static String GetSetting(String Key)
        {
            using (RegistryKey key1 = Application.UserAppDataRegistry.OpenSubKey(SECTION))
            {
                if (key1 != null)
                {
                    object obj1 = key1.GetValue(Key);

                    if (obj1 != null && obj1 is String)
                        return (String)obj1;
                }

                return null;
            }
        }
    }
}