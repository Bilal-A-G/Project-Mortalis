// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PcMap"",
            ""id"": ""b417260e-bce6-427a-bb8b-975623662196"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aa0f1931-6bbf-44ac-a33b-47844345893d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f36cd510-d7f4-4b75-814f-1a95059e7294"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a1b48782-1d0f-48cf-88b2-b682f90fee1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""bb993eb5-9742-4018-bd7d-e03eb3f516ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""fbfd07a9-ce81-4532-811f-8becb6eff6d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireGun"",
                    ""type"": ""Button"",
                    ""id"": ""7861c130-d89e-45e3-b870-8274e23ec9bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""415d43f0-477b-441d-8c69-dce8a00555f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""4b064989-ba2f-49a9-b1b9-33d5fbd70eed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""ca6d2d34-f23c-4c31-8442-ff651d5009b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""3013c609-d47d-4f5c-af63-849820270d9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MovementVector"",
                    ""id"": ""12812227-e847-427e-934a-c3c98a6fcf8c"",
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
                    ""id"": ""0e238372-3315-4215-8b2e-0d7c90c078b4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eee8f7ad-8f63-4f16-b898-9a782c333b86"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ba7dd373-0eee-47f0-bf43-2ae0893d6ba8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a8634ba5-9842-429f-afa3-164ab78b30b3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""072de658-3399-43a9-b0f1-606496f5aa72"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8f3b9ae-971c-4d6d-a12c-5cbc72e03025"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6982177-37f2-4d99-87da-f9c67c789e38"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff69bfae-e065-4c1f-939c-e7010f978d0a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c21e331-adbe-4202-a7ed-fead7674f31c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""FireGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1b397de-b9b3-45cc-84b7-f2f8c05433c3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f15aceb-8528-4754-80ae-434a216dbe31"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6878caa8-adfb-46f0-bce0-de438afd11e3"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""PrimaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0379a503-4829-4912-9bc3-d63c2cd09c8d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""SecondaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PcMap
        m_PcMap = asset.FindActionMap("PcMap", throwIfNotFound: true);
        m_PcMap_Movement = m_PcMap.FindAction("Movement", throwIfNotFound: true);
        m_PcMap_Look = m_PcMap.FindAction("Look", throwIfNotFound: true);
        m_PcMap_Jump = m_PcMap.FindAction("Jump", throwIfNotFound: true);
        m_PcMap_Run = m_PcMap.FindAction("Run", throwIfNotFound: true);
        m_PcMap_Crouch = m_PcMap.FindAction("Crouch", throwIfNotFound: true);
        m_PcMap_FireGun = m_PcMap.FindAction("FireGun", throwIfNotFound: true);
        m_PcMap_Reload = m_PcMap.FindAction("Reload", throwIfNotFound: true);
        m_PcMap_Aim = m_PcMap.FindAction("Aim", throwIfNotFound: true);
        m_PcMap_PrimaryWeapon = m_PcMap.FindAction("PrimaryWeapon", throwIfNotFound: true);
        m_PcMap_SecondaryWeapon = m_PcMap.FindAction("SecondaryWeapon", throwIfNotFound: true);
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

    // PcMap
    private readonly InputActionMap m_PcMap;
    private IPcMapActions m_PcMapActionsCallbackInterface;
    private readonly InputAction m_PcMap_Movement;
    private readonly InputAction m_PcMap_Look;
    private readonly InputAction m_PcMap_Jump;
    private readonly InputAction m_PcMap_Run;
    private readonly InputAction m_PcMap_Crouch;
    private readonly InputAction m_PcMap_FireGun;
    private readonly InputAction m_PcMap_Reload;
    private readonly InputAction m_PcMap_Aim;
    private readonly InputAction m_PcMap_PrimaryWeapon;
    private readonly InputAction m_PcMap_SecondaryWeapon;
    public struct PcMapActions
    {
        private @InputActions m_Wrapper;
        public PcMapActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PcMap_Movement;
        public InputAction @Look => m_Wrapper.m_PcMap_Look;
        public InputAction @Jump => m_Wrapper.m_PcMap_Jump;
        public InputAction @Run => m_Wrapper.m_PcMap_Run;
        public InputAction @Crouch => m_Wrapper.m_PcMap_Crouch;
        public InputAction @FireGun => m_Wrapper.m_PcMap_FireGun;
        public InputAction @Reload => m_Wrapper.m_PcMap_Reload;
        public InputAction @Aim => m_Wrapper.m_PcMap_Aim;
        public InputAction @PrimaryWeapon => m_Wrapper.m_PcMap_PrimaryWeapon;
        public InputAction @SecondaryWeapon => m_Wrapper.m_PcMap_SecondaryWeapon;
        public InputActionMap Get() { return m_Wrapper.m_PcMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PcMapActions set) { return set.Get(); }
        public void SetCallbacks(IPcMapActions instance)
        {
            if (m_Wrapper.m_PcMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnRun;
                @Crouch.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnCrouch;
                @FireGun.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnFireGun;
                @FireGun.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnFireGun;
                @FireGun.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnFireGun;
                @Reload.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnReload;
                @Aim.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnAim;
                @PrimaryWeapon.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnPrimaryWeapon;
                @PrimaryWeapon.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnPrimaryWeapon;
                @PrimaryWeapon.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnPrimaryWeapon;
                @SecondaryWeapon.started -= m_Wrapper.m_PcMapActionsCallbackInterface.OnSecondaryWeapon;
                @SecondaryWeapon.performed -= m_Wrapper.m_PcMapActionsCallbackInterface.OnSecondaryWeapon;
                @SecondaryWeapon.canceled -= m_Wrapper.m_PcMapActionsCallbackInterface.OnSecondaryWeapon;
            }
            m_Wrapper.m_PcMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @FireGun.started += instance.OnFireGun;
                @FireGun.performed += instance.OnFireGun;
                @FireGun.canceled += instance.OnFireGun;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @PrimaryWeapon.started += instance.OnPrimaryWeapon;
                @PrimaryWeapon.performed += instance.OnPrimaryWeapon;
                @PrimaryWeapon.canceled += instance.OnPrimaryWeapon;
                @SecondaryWeapon.started += instance.OnSecondaryWeapon;
                @SecondaryWeapon.performed += instance.OnSecondaryWeapon;
                @SecondaryWeapon.canceled += instance.OnSecondaryWeapon;
            }
        }
    }
    public PcMapActions @PcMap => new PcMapActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IPcMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnFireGun(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnPrimaryWeapon(InputAction.CallbackContext context);
        void OnSecondaryWeapon(InputAction.CallbackContext context);
    }
}
