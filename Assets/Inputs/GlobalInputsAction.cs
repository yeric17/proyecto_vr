// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/GlobalInputsAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GlobalInputsAction : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public GlobalInputsAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GlobalInputsAction"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""868d95da-1fba-45db-b4a8-eb57b1e339d6"",
            ""actions"": [
                {
                    ""name"": ""YRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f0f2920-afb0-43df-b69e-a222b3fa46fe"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""XRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ee28c560-4b3b-40c7-8784-17b0ab3a4467"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6aa55b96-98a5-4780-b96e-dd73a55f1ee7"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""548af325-aefb-4ce7-904b-363d42291334"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_YRotation = m_PlayerControls.FindAction("YRotation", throwIfNotFound: true);
        m_PlayerControls_XRotation = m_PlayerControls.FindAction("XRotation", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_YRotation;
    private readonly InputAction m_PlayerControls_XRotation;
    public struct PlayerControlsActions
    {
        private GlobalInputsAction m_Wrapper;
        public PlayerControlsActions(GlobalInputsAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @YRotation => m_Wrapper.m_PlayerControls_YRotation;
        public InputAction @XRotation => m_Wrapper.m_PlayerControls_XRotation;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                YRotation.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnYRotation;
                YRotation.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnYRotation;
                YRotation.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnYRotation;
                XRotation.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXRotation;
                XRotation.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXRotation;
                XRotation.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXRotation;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                YRotation.started += instance.OnYRotation;
                YRotation.performed += instance.OnYRotation;
                YRotation.canceled += instance.OnYRotation;
                XRotation.started += instance.OnXRotation;
                XRotation.performed += instance.OnXRotation;
                XRotation.canceled += instance.OnXRotation;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnYRotation(InputAction.CallbackContext context);
        void OnXRotation(InputAction.CallbackContext context);
    }
}
