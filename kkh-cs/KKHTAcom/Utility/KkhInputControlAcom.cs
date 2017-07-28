using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Acom.Utility
{
    class KkhInputControlAcom
    {
        /// <summary>
        /// システム文字かを返す
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Boolean IsSystemChar( char code )
        {
            return (
                ( code == '\b' )
            );
        }

        /// <summary>
        /// 英字かを返す
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Boolean IsAlphaChar( char code )
        {
            return (
                ( ( code >= 'A' ) && ( code <= 'Z' ) ) ||
                ( ( code >= 'a' ) && ( code <= 'z' ) )
            );
        }

        /// <summary>
        /// 数字かを返す
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Boolean IsNumberChar( char code )
        {
            return (
                ( code >= '0' ) && ( code <= '9' )
            );
        }

        /// <summary>
        /// キー入力制限（英字のみ） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress_InputControlAlphaOnly(object sender, KeyPressEventArgs e)
        {
            if (!( IsSystemChar(e.KeyChar) || IsAlphaChar(e.KeyChar) ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// キー入力制限（数字のみ） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress_InputControlNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!( IsSystemChar(e.KeyChar) || IsNumberChar(e.KeyChar) ))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// キー入力制限（英字と数字のみ） 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void KeyPress_InputControlAlphaAndNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!( IsSystemChar(e.KeyChar) || IsAlphaChar(e.KeyChar) || IsNumberChar(e.KeyChar) ))
            {
                e.Handled = true;
            }
        }
    }
}
