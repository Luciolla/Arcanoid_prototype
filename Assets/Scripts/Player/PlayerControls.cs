//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.1
//     from Assets/Scripts/Player/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Arcanoid.Player
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""FirstPlayer"",
            ""id"": ""85150b36-5b81-4871-a023-520b746ead96"",
            ""actions"": [
                {
                    ""name"": ""Motion"",
                    ""type"": ""Value"",
                    ""id"": ""216da389-dfd5-4db2-b715-6ee944eb099f"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""GameStart"",
                    ""type"": ""Button"",
                    ""id"": ""c30c336f-3077-43ec-ba12-541cbd49905c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9370f013-cc65-4ad9-9adf-5d14b38f0a33"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec89bee0-7eca-4e35-b7ce-90aebcb664b1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""28083bd0-2255-44ab-8723-c5220c53e9f3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""e732fdcf-7b36-4caa-9aae-5a8e552fc5f8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""49f63c82-e789-40d2-a4e1-3bf11ad979d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9cda3e6f-ad97-41c3-b9a6-de8106098d4e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GameStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SecondPlayer"",
            ""id"": ""d1ca9f8c-d463-4279-ba16-4858cda59717"",
            ""actions"": [
                {
                    ""name"": ""Motion"",
                    ""type"": ""Value"",
                    ""id"": ""e55cb85a-3200-4914-8d20-43ba5006dd62"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6218217a-ee76-46fc-899b-af455ac6a1c4"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""11e37dff-679f-424e-a06a-d4b90c20c8dc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f91b318d-31ba-4f2b-b2b4-b80dd9ead2b6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""3dda13fd-a8ba-49dd-99db-8b5ac1e9c605"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""5b3ea6b1-73a2-43ed-883d-95e2060a79a4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Motion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // FirstPlayer
            m_FirstPlayer = asset.FindActionMap("FirstPlayer", throwIfNotFound: true);
            m_FirstPlayer_Motion = m_FirstPlayer.FindAction("Motion", throwIfNotFound: true);
            m_FirstPlayer_GameStart = m_FirstPlayer.FindAction("GameStart", throwIfNotFound: true);
            // SecondPlayer
            m_SecondPlayer = asset.FindActionMap("SecondPlayer", throwIfNotFound: true);
            m_SecondPlayer_Motion = m_SecondPlayer.FindAction("Motion", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // FirstPlayer
        private readonly InputActionMap m_FirstPlayer;
        private IFirstPlayerActions m_FirstPlayerActionsCallbackInterface;
        private readonly InputAction m_FirstPlayer_Motion;
        private readonly InputAction m_FirstPlayer_GameStart;
        public struct FirstPlayerActions
        {
            private @PlayerControls m_Wrapper;
            public FirstPlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Motion => m_Wrapper.m_FirstPlayer_Motion;
            public InputAction @GameStart => m_Wrapper.m_FirstPlayer_GameStart;
            public InputActionMap Get() { return m_Wrapper.m_FirstPlayer; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(FirstPlayerActions set) { return set.Get(); }
            public void SetCallbacks(IFirstPlayerActions instance)
            {
                if (m_Wrapper.m_FirstPlayerActionsCallbackInterface != null)
                {
                    @Motion.started -= m_Wrapper.m_FirstPlayerActionsCallbackInterface.OnMotion;
                    @Motion.performed -= m_Wrapper.m_FirstPlayerActionsCallbackInterface.OnMotion;
                    @Motion.canceled -= m_Wrapper.m_FirstPlayerActionsCallbackInterface.OnMotion;
                    @GameStart.started -= m_Wrapper.m_FirstPlayerActionsCallbackInterface.OnGameStart;
                    @GameStart.performed -= m_Wrapper.m_FirstPlayerActionsCallbackInterface.OnGameStart;
                    @GameStart.canceled -= m_Wrapper.m_FirstPlayerActionsCallbackInterface.OnGameStart;
                }
                m_Wrapper.m_FirstPlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Motion.started += instance.OnMotion;
                    @Motion.performed += instance.OnMotion;
                    @Motion.canceled += instance.OnMotion;
                    @GameStart.started += instance.OnGameStart;
                    @GameStart.performed += instance.OnGameStart;
                    @GameStart.canceled += instance.OnGameStart;
                }
            }
        }
        public FirstPlayerActions @FirstPlayer => new FirstPlayerActions(this);

        // SecondPlayer
        private readonly InputActionMap m_SecondPlayer;
        private ISecondPlayerActions m_SecondPlayerActionsCallbackInterface;
        private readonly InputAction m_SecondPlayer_Motion;
        public struct SecondPlayerActions
        {
            private @PlayerControls m_Wrapper;
            public SecondPlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Motion => m_Wrapper.m_SecondPlayer_Motion;
            public InputActionMap Get() { return m_Wrapper.m_SecondPlayer; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SecondPlayerActions set) { return set.Get(); }
            public void SetCallbacks(ISecondPlayerActions instance)
            {
                if (m_Wrapper.m_SecondPlayerActionsCallbackInterface != null)
                {
                    @Motion.started -= m_Wrapper.m_SecondPlayerActionsCallbackInterface.OnMotion;
                    @Motion.performed -= m_Wrapper.m_SecondPlayerActionsCallbackInterface.OnMotion;
                    @Motion.canceled -= m_Wrapper.m_SecondPlayerActionsCallbackInterface.OnMotion;
                }
                m_Wrapper.m_SecondPlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Motion.started += instance.OnMotion;
                    @Motion.performed += instance.OnMotion;
                    @Motion.canceled += instance.OnMotion;
                }
            }
        }
        public SecondPlayerActions @SecondPlayer => new SecondPlayerActions(this);
        public interface IFirstPlayerActions
        {
            void OnMotion(InputAction.CallbackContext context);
            void OnGameStart(InputAction.CallbackContext context);
        }
        public interface ISecondPlayerActions
        {
            void OnMotion(InputAction.CallbackContext context);
        }
    }
}
