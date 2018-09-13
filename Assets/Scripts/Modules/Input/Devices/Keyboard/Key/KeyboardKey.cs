using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NoMansBlocks.Modules.Input.Devices {
    /// <summary>
    /// All of the possible supported keyboard keys.
    /// </summary>
    public enum KeyboardKey : byte {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        Alpha0,
        Alpha1,
        Alpha2,
        Alpha3,
        Alpha4,
        Alpha5,
        Alpha6,
        Alpha7,
        Alpha8,
        Alpha9,
        BackQuote,
        ForwardQuote,
        DoubleQuote,
        Semicolon,
        LeftBracket,
        RightBracket,
        ForwardSlash,
        BackSlash,
        LeftShift,
        RightShift,
        LeftControl,
        RightControl,
        LeftAlt,
        RightAlt,
        CapsLock,
        Tab,
        AlphaEnter,
        Backspace,
        Delete,
        Escape,
        Insert,
        Home,
        PageUp,
        PageDown,
        End,
        UpArrow,
        DownArrow,
        LeftArrow,
        RightArrow,
        Minus,
        Plus,
        Keypad0,
        Keypad1,
        Keypad2,
        Keypad3,
        Keypad4,
        Keypad5,
        Keypad6,
        Keypad7,
        Keypad8,
        Keypad9,
        KeypadEnter,
        KeypadPlus,
        KeypadMinus,
        KeypadMultiply,
        KeypadDivide,
        KeypadPeriod,
    }

    /// <summary>
    /// Container for creating extensions for the KeyboardKey
    /// enum. Nothing else should be put in here.
    /// </summary>
    public static class KeyboardKeyExtensions {
        /// <summary>
        /// Takes an input of a keyboard key and converts it
        /// to Unitys KeyCode variant.
        /// </summary>
        /// <param name="key">The keyboard key to convert.</param>
        /// <returns>The Unity keycode.</returns>
        public static KeyCode ToKeyCode(this KeyboardKey key) {
            switch (key) {
                case KeyboardKey.A:
                    return KeyCode.A;
                case KeyboardKey.B:
                    return KeyCode.B;
                case KeyboardKey.C:
                    return KeyCode.C;
                case KeyboardKey.D:
                    return KeyCode.D;
                case KeyboardKey.E:
                    return KeyCode.E;
                case KeyboardKey.F:
                    return KeyCode.F;
                case KeyboardKey.G:
                    return KeyCode.G;
                case KeyboardKey.H:
                    return KeyCode.H;
                case KeyboardKey.I:
                    return KeyCode.I;
                case KeyboardKey.J:
                    return KeyCode.J;
                case KeyboardKey.K:
                    return KeyCode.K;
                case KeyboardKey.L:
                    return KeyCode.L;
                case KeyboardKey.M:
                    return KeyCode.M;
                case KeyboardKey.N:
                    return KeyCode.N;
                case KeyboardKey.O:
                    return KeyCode.O;
                case KeyboardKey.P:
                    return KeyCode.P;
                case KeyboardKey.Q:
                    return KeyCode.Q;
                case KeyboardKey.R:
                    return KeyCode.R;
                case KeyboardKey.S:
                    return KeyCode.S;
                case KeyboardKey.T:
                    return KeyCode.T;
                case KeyboardKey.U:
                    return KeyCode.U;
                case KeyboardKey.V:
                    return KeyCode.V;
                case KeyboardKey.W:
                    return KeyCode.W;
                case KeyboardKey.X:
                    return KeyCode.X;
                case KeyboardKey.Y:
                    return KeyCode.Y;
                case KeyboardKey.Z:
                    return KeyCode.Z;
                case KeyboardKey.Alpha0:
                    return KeyCode.Alpha0;
                case KeyboardKey.Alpha1:
                    return KeyCode.Alpha1;
                case KeyboardKey.Alpha2:
                    return KeyCode.Alpha2;
                case KeyboardKey.Alpha3:
                    return KeyCode.Alpha3;
                case KeyboardKey.Alpha4:
                    return KeyCode.Alpha4;
                case KeyboardKey.Alpha5:
                    return KeyCode.Alpha5;
                case KeyboardKey.Alpha6:
                    return KeyCode.Alpha6;
                case KeyboardKey.Alpha7:
                    return KeyCode.Alpha7;
                case KeyboardKey.Alpha8:
                    return KeyCode.Alpha8;
                case KeyboardKey.Alpha9:
                    return KeyCode.Alpha9;
                case KeyboardKey.BackQuote:
                    return KeyCode.BackQuote;
                case KeyboardKey.ForwardQuote:
                    return KeyCode.Quote;
                case KeyboardKey.DoubleQuote:
                    return KeyCode.DoubleQuote;
                case KeyboardKey.Semicolon:
                    return KeyCode.Semicolon;
                case KeyboardKey.LeftBracket:
                    return KeyCode.LeftBracket;
                case KeyboardKey.RightBracket:
                    return KeyCode.RightBracket;
                case KeyboardKey.ForwardSlash:
                    return KeyCode.Slash;
                case KeyboardKey.BackSlash:
                    return KeyCode.Backslash;
                case KeyboardKey.LeftShift:
                    return KeyCode.LeftShift;
                case KeyboardKey.RightShift:
                    return KeyCode.RightShift;
                case KeyboardKey.LeftControl:
                    return KeyCode.LeftControl;
                case KeyboardKey.RightControl:
                    return KeyCode.RightControl;
                case KeyboardKey.LeftAlt:
                    return KeyCode.LeftAlt;
                case KeyboardKey.RightAlt:
                    return KeyCode.RightAlt;
                case KeyboardKey.CapsLock:
                    return KeyCode.CapsLock;
                case KeyboardKey.Tab:
                    return KeyCode.Tab;
                case KeyboardKey.AlphaEnter:
                    return KeyCode.Return;
                case KeyboardKey.Backspace:
                    return KeyCode.Backspace;
                case KeyboardKey.Delete:
                    return KeyCode.Delete;
                case KeyboardKey.Escape:
                    return KeyCode.Escape;
                case KeyboardKey.Insert:
                    return KeyCode.Insert;
                case KeyboardKey.Home:
                    return KeyCode.Home;
                case KeyboardKey.PageUp:
                    return KeyCode.PageUp;
                case KeyboardKey.PageDown:
                    return KeyCode.PageDown;
                case KeyboardKey.End:
                    return KeyCode.End;
                case KeyboardKey.UpArrow:
                    return KeyCode.UpArrow;
                case KeyboardKey.DownArrow:
                    return KeyCode.DownArrow;
                case KeyboardKey.LeftArrow:
                    return KeyCode.LeftArrow;
                case KeyboardKey.RightArrow:
                    return KeyCode.RightArrow;
                case KeyboardKey.Minus:
                    return KeyCode.Minus;
                case KeyboardKey.Plus:
                    return KeyCode.Plus;
                case KeyboardKey.Keypad0:
                    return KeyCode.Keypad0;
                case KeyboardKey.Keypad1:
                    return KeyCode.Keypad1;
                case KeyboardKey.Keypad2:
                    return KeyCode.Keypad2;
                case KeyboardKey.Keypad3:
                    return KeyCode.Keypad3;
                case KeyboardKey.Keypad4:
                    return KeyCode.Keypad4;
                case KeyboardKey.Keypad5:
                    return KeyCode.Keypad5;
                case KeyboardKey.Keypad6:
                    return KeyCode.Keypad6;
                case KeyboardKey.Keypad7:
                    return KeyCode.Keypad7;
                case KeyboardKey.Keypad8:
                    return KeyCode.Keypad8;
                case KeyboardKey.Keypad9:
                    return KeyCode.Keypad9;
                case KeyboardKey.KeypadEnter:
                    return KeyCode.KeypadEnter;
                case KeyboardKey.KeypadPlus:
                    return KeyCode.KeypadPlus;
                case KeyboardKey.KeypadMinus:
                    return KeyCode.KeypadMinus;
                case KeyboardKey.KeypadMultiply:
                    return KeyCode.KeypadMultiply;
                case KeyboardKey.KeypadDivide:
                    return KeyCode.KeypadDivide;
                case KeyboardKey.KeypadPeriod:
                    return KeyCode.KeypadPeriod;
                default:
                    throw new NotSupportedException(string.Format("KeyboardKey: {0} is not supported.", key.ToString()));
            }
        }
    }
}