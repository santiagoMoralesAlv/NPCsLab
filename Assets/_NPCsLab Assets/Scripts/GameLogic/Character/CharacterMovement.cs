// GENERATED AUTOMATICALLY FROM 'Assets/_NPCsLab Assets/Scripts/GameLogic/Character/PlayerControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterMovInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterMovInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""55728df6-6155-4e80-961f-92ea2b420d71"",
            ""actions"": [
                {
                    ""name"": ""PrimaryPress"",
                    ""type"": ""Button"",
                    ""id"": ""5d71df34-d23b-49bb-a8b8-1f07dfc7c072"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""51bd50ff-e4ce-4f5e-bd0e-ae1a3792eb80"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1c5279ad-c37c-4c92-b6cd-0fcdd5ab6037"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f0582139-20be-4148-8d1a-7ec64a1f6ac3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5931dca3-9131-4972-b758-96000963f47a"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6825884a-0725-4adf-af70-24e5960cf8dc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef12dd8d-35ee-4167-810a-a21565362f0f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63c71b46-078a-4a58-ba53-16fbb148ca5e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a65ac69-9fe2-4417-8652-2bc6cb84fb3b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1098e1d7-fe48-45fc-97bd-72baeb541da3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0e14f25-ee6e-4e97-bbfd-8d13fcdc9fe6"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""PrimaryPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_PrimaryPress = m_General.FindAction("PrimaryPress", throwIfNotFound: true);
        m_General_PrimaryPosition = m_General.FindAction("PrimaryPosition", throwIfNotFound: true);
        m_General_Jump = m_General.FindAction("Jump", throwIfNotFound: true);
        m_General_Slide = m_General.FindAction("Slide", throwIfNotFound: true);
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

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_PrimaryPress;
    private readonly InputAction m_General_PrimaryPosition;
    private readonly InputAction m_General_Jump;
    private readonly InputAction m_General_Slide;
    public struct GeneralActions
    {
        private @CharacterMovInput m_Wrapper;
        public GeneralActions(@CharacterMovInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryPress => m_Wrapper.m_General_PrimaryPress;
        public InputAction @PrimaryPosition => m_Wrapper.m_General_PrimaryPosition;
        public InputAction @Jump => m_Wrapper.m_General_Jump;
        public InputAction @Slide => m_Wrapper.m_General_Slide;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @PrimaryPress.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPrimaryPress;
                @PrimaryPress.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPrimaryPress;
                @PrimaryPress.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPrimaryPress;
                @PrimaryPosition.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnPrimaryPosition;
                @Jump.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnJump;
                @Slide.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSlide;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryPress.started += instance.OnPrimaryPress;
                @PrimaryPress.performed += instance.OnPrimaryPress;
                @PrimaryPress.canceled += instance.OnPrimaryPress;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IGeneralActions
    {
        void OnPrimaryPress(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
    }
}
