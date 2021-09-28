// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""792c0c3a-7de0-41a9-bf6f-b49a32fbe9cb"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""87bec06b-7c49-4c48-826a-ec0b9ebf48df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""9a531c6c-9aed-471f-bbca-ddd62b515411"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityOne"",
                    ""type"": ""Button"",
                    ""id"": ""9b07f307-6d8c-4e4a-85a4-4d9b54b9ff1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityTwo"",
                    ""type"": ""Button"",
                    ""id"": ""49c77f98-32e2-498b-8a43-db63c885157b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityThree"",
                    ""type"": ""Button"",
                    ""id"": ""906015b8-af29-409f-825e-1ad9a9723109"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityFour"",
                    ""type"": ""Button"",
                    ""id"": ""ce3cc3c4-3a1f-4e83-bc5d-a821629d5a76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""91acbf73-1ba9-4667-8ee8-5b2e7483e6e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""42d73e4a-0090-4033-8b72-c9c1acf7c5eb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9a702073-8bca-4dab-96aa-b4cbc53b1561"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f2fb544d-e0b1-43f2-b63a-9966b0052de0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60a4a019-16dd-420b-85b2-cdee39399645"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""049a1180-486a-43f5-bac8-718b7b955558"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71be5dd9-5c40-47bc-9199-b8e51c6353be"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c639ced-30f9-4437-95b1-fef18f4a187f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a632e94-c809-425b-9c3e-b2f3a0822365"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1026d82b-e957-47b7-9e04-1e011fc13f42"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6dc14d1-696e-456b-afa5-42973ea53942"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityFour"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f50176ed-0e88-4f6e-acb6-19d7002d03bb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Shoot = m_PlayerControls.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerControls_AbilityOne = m_PlayerControls.FindAction("AbilityOne", throwIfNotFound: true);
        m_PlayerControls_AbilityTwo = m_PlayerControls.FindAction("AbilityTwo", throwIfNotFound: true);
        m_PlayerControls_AbilityThree = m_PlayerControls.FindAction("AbilityThree", throwIfNotFound: true);
        m_PlayerControls_AbilityFour = m_PlayerControls.FindAction("AbilityFour", throwIfNotFound: true);
        m_PlayerControls_LeftClick = m_PlayerControls.FindAction("LeftClick", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Shoot;
    private readonly InputAction m_PlayerControls_AbilityOne;
    private readonly InputAction m_PlayerControls_AbilityTwo;
    private readonly InputAction m_PlayerControls_AbilityThree;
    private readonly InputAction m_PlayerControls_AbilityFour;
    private readonly InputAction m_PlayerControls_LeftClick;
    public struct PlayerControlsActions
    {
        private @Controls m_Wrapper;
        public PlayerControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Shoot => m_Wrapper.m_PlayerControls_Shoot;
        public InputAction @AbilityOne => m_Wrapper.m_PlayerControls_AbilityOne;
        public InputAction @AbilityTwo => m_Wrapper.m_PlayerControls_AbilityTwo;
        public InputAction @AbilityThree => m_Wrapper.m_PlayerControls_AbilityThree;
        public InputAction @AbilityFour => m_Wrapper.m_PlayerControls_AbilityFour;
        public InputAction @LeftClick => m_Wrapper.m_PlayerControls_LeftClick;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @AbilityOne.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityOne;
                @AbilityOne.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityOne;
                @AbilityOne.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityOne;
                @AbilityTwo.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityTwo;
                @AbilityTwo.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityTwo;
                @AbilityTwo.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityTwo;
                @AbilityThree.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityThree;
                @AbilityThree.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityThree;
                @AbilityThree.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityThree;
                @AbilityFour.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityFour;
                @AbilityFour.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityFour;
                @AbilityFour.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAbilityFour;
                @LeftClick.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLeftClick;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @AbilityOne.started += instance.OnAbilityOne;
                @AbilityOne.performed += instance.OnAbilityOne;
                @AbilityOne.canceled += instance.OnAbilityOne;
                @AbilityTwo.started += instance.OnAbilityTwo;
                @AbilityTwo.performed += instance.OnAbilityTwo;
                @AbilityTwo.canceled += instance.OnAbilityTwo;
                @AbilityThree.started += instance.OnAbilityThree;
                @AbilityThree.performed += instance.OnAbilityThree;
                @AbilityThree.canceled += instance.OnAbilityThree;
                @AbilityFour.started += instance.OnAbilityFour;
                @AbilityFour.performed += instance.OnAbilityFour;
                @AbilityFour.canceled += instance.OnAbilityFour;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnAbilityOne(InputAction.CallbackContext context);
        void OnAbilityTwo(InputAction.CallbackContext context);
        void OnAbilityThree(InputAction.CallbackContext context);
        void OnAbilityFour(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
    }
}
