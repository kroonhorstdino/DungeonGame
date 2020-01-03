// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Ingame"",
            ""id"": ""e41f498a-5f50-475f-92eb-f7e87c879e33"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""6008ef94-12ec-42e2-bf65-06c545bc57e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TestAction"",
                    ""type"": ""Button"",
                    ""id"": ""ae3372a1-4103-4277-af10-a0604edcc81a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PunchSimple"",
                    ""type"": ""Button"",
                    ""id"": ""701f4829-b289-4b39-9621-68554f020522"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""896dc3cd-6572-41fa-8f80-7ed37f1c864c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Controller"",
                    ""id"": ""e6c749c3-f589-4466-9c65-f14d2521228d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""80a59ff2-ebde-4281-97bc-15fbba6de4c2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a2b0010b-dcc0-467c-bc6f-e4108fb9f969"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e76baf05-6068-4421-980a-df513ed069a4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a7e4afe4-1701-4ff3-b052-b7e00442fc88"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""9ace9334-9c96-4264-a342-a5c909700e70"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""c4bfe65c-6ed0-44b9-bbf8-bcfb36b3b91c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""35bc879c-83f3-426e-9b21-55bf5fc7d7c1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""37e70fa8-1344-423f-9f6b-c4959e6bcdc6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b04d83d5-92f0-4c3a-be30-1cd6a7d6487c"",
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
                    ""id"": ""14bce6ac-9e6f-4525-ad74-6807263a845b"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""TestAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""176417ef-af30-4f2c-92e7-c34f58a265c8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PunchSimple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""937cf865-c742-450d-9583-22771c992599"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""PunchSimple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""747683c7-c668-4a0b-a2c4-27554060b16e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""PunchSimple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6fe81304-4e58-4fc3-90bf-7577718addcd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4e1e27f4-327f-4a45-8940-2cd2a0c9a5e2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""af15dc45-d5a8-44b4-af77-f06df810086d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""MenuIngame"",
            ""id"": ""7e47fc87-f872-4d25-8dd5-c63fdc9ebcc7"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""2d5303b0-3760-4ffd-ba8a-de9ea1004c1f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5b38b72-c516-4ec5-8339-8f1b125a51d1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuPause"",
            ""id"": ""a734a513-b587-4724-8864-7a4b87f604ff"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""2881d49e-771e-4bf2-8b0e-864a5c07ff4e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ecccb89a-c43e-4bda-9978-2e102c500bdc"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
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
        // Ingame
        m_Ingame = asset.FindActionMap("Ingame", throwIfNotFound: true);
        m_Ingame_Movement = m_Ingame.FindAction("Movement", throwIfNotFound: true);
        m_Ingame_TestAction = m_Ingame.FindAction("TestAction", throwIfNotFound: true);
        m_Ingame_PunchSimple = m_Ingame.FindAction("PunchSimple", throwIfNotFound: true);
        m_Ingame_Jump = m_Ingame.FindAction("Jump", throwIfNotFound: true);
        // MenuIngame
        m_MenuIngame = asset.FindActionMap("MenuIngame", throwIfNotFound: true);
        m_MenuIngame_Newaction = m_MenuIngame.FindAction("New action", throwIfNotFound: true);
        // MenuPause
        m_MenuPause = asset.FindActionMap("MenuPause", throwIfNotFound: true);
        m_MenuPause_Newaction = m_MenuPause.FindAction("New action", throwIfNotFound: true);
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

    // Ingame
    private readonly InputActionMap m_Ingame;
    private IIngameActions m_IngameActionsCallbackInterface;
    private readonly InputAction m_Ingame_Movement;
    private readonly InputAction m_Ingame_TestAction;
    private readonly InputAction m_Ingame_PunchSimple;
    private readonly InputAction m_Ingame_Jump;
    public struct IngameActions
    {
        private @PlayerInputActions m_Wrapper;
        public IngameActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Ingame_Movement;
        public InputAction @TestAction => m_Wrapper.m_Ingame_TestAction;
        public InputAction @PunchSimple => m_Wrapper.m_Ingame_PunchSimple;
        public InputAction @Jump => m_Wrapper.m_Ingame_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Ingame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(IngameActions set) { return set.Get(); }
        public void SetCallbacks(IIngameActions instance)
        {
            if (m_Wrapper.m_IngameActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnMovement;
                @TestAction.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnTestAction;
                @TestAction.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnTestAction;
                @TestAction.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnTestAction;
                @PunchSimple.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnPunchSimple;
                @PunchSimple.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnPunchSimple;
                @PunchSimple.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnPunchSimple;
                @Jump.started -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_IngameActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_IngameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @TestAction.started += instance.OnTestAction;
                @TestAction.performed += instance.OnTestAction;
                @TestAction.canceled += instance.OnTestAction;
                @PunchSimple.started += instance.OnPunchSimple;
                @PunchSimple.performed += instance.OnPunchSimple;
                @PunchSimple.canceled += instance.OnPunchSimple;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public IngameActions @Ingame => new IngameActions(this);

    // MenuIngame
    private readonly InputActionMap m_MenuIngame;
    private IMenuIngameActions m_MenuIngameActionsCallbackInterface;
    private readonly InputAction m_MenuIngame_Newaction;
    public struct MenuIngameActions
    {
        private @PlayerInputActions m_Wrapper;
        public MenuIngameActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MenuIngame_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MenuIngame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuIngameActions set) { return set.Get(); }
        public void SetCallbacks(IMenuIngameActions instance)
        {
            if (m_Wrapper.m_MenuIngameActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuIngameActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuIngameActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuIngameActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuIngameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuIngameActions @MenuIngame => new MenuIngameActions(this);

    // MenuPause
    private readonly InputActionMap m_MenuPause;
    private IMenuPauseActions m_MenuPauseActionsCallbackInterface;
    private readonly InputAction m_MenuPause_Newaction;
    public struct MenuPauseActions
    {
        private @PlayerInputActions m_Wrapper;
        public MenuPauseActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_MenuPause_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_MenuPause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuPauseActions set) { return set.Get(); }
        public void SetCallbacks(IMenuPauseActions instance)
        {
            if (m_Wrapper.m_MenuPauseActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuPauseActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuPauseActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuPauseActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuPauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuPauseActions @MenuPause => new MenuPauseActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IIngameActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTestAction(InputAction.CallbackContext context);
        void OnPunchSimple(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IMenuIngameActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IMenuPauseActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
