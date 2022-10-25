// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""f654dd06-1e03-4701-ae4c-065c2b98e73f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""5bc753cc-4bdb-4348-917c-db79aa8fdd0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b16ac961-8905-4dbf-b897-5743ef1c7873"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LampLRControl"",
                    ""type"": ""Button"",
                    ""id"": ""488cf842-e7be-4ebd-af7a-6f420471ae41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LampTDControl"",
                    ""type"": ""Button"",
                    ""id"": ""840eed71-693d-4a3c-b8d2-9264b46886db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TimeRewind"",
                    ""type"": ""Button"",
                    ""id"": ""86733a56-f603-43d9-9fcc-54412d79a75b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Walk"",
                    ""type"": ""Button"",
                    ""id"": ""38ab001a-76c9-4c6a-a426-c408694fd5ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbsorbShadow"",
                    ""type"": ""Button"",
                    ""id"": ""55a6d8fc-5640-4754-b627-40d974d056c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReleaseShadow"",
                    ""type"": ""Button"",
                    ""id"": ""d2492a3c-cc85-4e6c-be6a-3c544d150950"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""SideWay"",
                    ""id"": ""e9c6b43a-4ecb-4162-a126-f1bb5e689ce1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e04b6637-84f5-44f6-8b70-c583e47c3f44"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""83955129-95d5-444d-94ef-51c07475c8c8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""962dda56-49f9-4e5c-a9d9-eaef9d97e139"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LeftAndRight"",
                    ""id"": ""3f5e88c7-8d4b-493c-9ed0-3813d1a3ba98"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LampLRControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""47b51ea7-c4b1-468e-bd26-258f859501b8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LampLRControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""279113ea-7992-413b-a395-4dbb1f0002da"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LampLRControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TopAndDown"",
                    ""id"": ""7c41640d-a4cf-4aea-b0dd-453d55365fc9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LampTDControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""36e37720-080f-4be2-ab27-209896074627"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LampTDControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9e75cd38-bd03-47a1-b41d-89f4fce7b8c8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LampTDControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""475f00c0-3b9e-4d88-9d5b-381957413baf"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TimeRewind"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc4f84fb-1280-4893-9cad-e903192d1c53"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dd20824-02ba-45aa-b60d-a34c0a159fda"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbsorbShadow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e2c4125-2d29-4b96-84e4-1304cbfb4c9b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseShadow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""a633f8ea-046a-449e-a155-565e5c0ba446"",
            ""actions"": [
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""9a910f12-5a67-420e-849d-3df246c28557"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandTDControl"",
                    ""type"": ""Button"",
                    ""id"": ""c5a8c957-a33f-4636-9039-28ae25a0627b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandTDRotateControl"",
                    ""type"": ""Button"",
                    ""id"": ""0751c85b-6da9-473d-bcc4-6f5a511ed99f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandLRControl"",
                    ""type"": ""Button"",
                    ""id"": ""5bc5aac5-2488-4416-919e-bab4f90c4d68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandLRRotateControl"",
                    ""type"": ""Button"",
                    ""id"": ""0ba4bc42-059f-4d22-8a5e-43685befe118"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GenerateShadowGround"",
                    ""type"": ""Button"",
                    ""id"": ""bd93d861-c87d-4b53-a0f3-e71a7c7431eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ad3b6b4e-6910-4d7e-afb9-9d8c61eb33fd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LeftAndRight"",
                    ""id"": ""dc2cd486-d986-4ced-86d3-e0c856c4a157"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandLRControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cc1cb1b1-f6f6-45d6-a379-94d3e46bf938"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandLRControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6b21d3c7-b461-431c-ab81-de0eaf789200"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandLRControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TopAndDown"",
                    ""id"": ""7e78f2e1-4e6d-4887-939a-d75c7f5ce33a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandTDControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3f0df1c8-cf3a-453d-9e2f-6d0d8c210f68"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandTDControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""29b66388-b2b2-4b75-8424-6168927e929a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandTDControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TopAndDown"",
                    ""id"": ""f174df6d-697b-4b46-8805-164226c1c191"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandTDRotateControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a8fa9ed3-e5cf-40d5-ac00-018bdc40eade"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandTDRotateControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5c5667d8-a6f0-485a-8f53-2b9f3c9679ae"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandTDRotateControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftAndRight"",
                    ""id"": ""a0062636-645d-4791-b246-cfe8c8a87622"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandLRRotateControl"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8d705959-0454-4bd8-974e-14996071f755"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandLRRotateControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""50c28a7e-7158-4dba-9201-c1228f15d33d"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandLRRotateControl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""05f210cc-20b6-4957-8598-df8f064cb493"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GenerateShadowGround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Move = m_Player1.FindAction("Move", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_LampLRControl = m_Player1.FindAction("LampLRControl", throwIfNotFound: true);
        m_Player1_LampTDControl = m_Player1.FindAction("LampTDControl", throwIfNotFound: true);
        m_Player1_TimeRewind = m_Player1.FindAction("TimeRewind", throwIfNotFound: true);
        m_Player1_Move_Walk = m_Player1.FindAction("Move_Walk", throwIfNotFound: true);
        m_Player1_AbsorbShadow = m_Player1.FindAction("AbsorbShadow", throwIfNotFound: true);
        m_Player1_ReleaseShadow = m_Player1.FindAction("ReleaseShadow", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Hold = m_Player2.FindAction("Hold", throwIfNotFound: true);
        m_Player2_HandTDControl = m_Player2.FindAction("HandTDControl", throwIfNotFound: true);
        m_Player2_HandTDRotateControl = m_Player2.FindAction("HandTDRotateControl", throwIfNotFound: true);
        m_Player2_HandLRControl = m_Player2.FindAction("HandLRControl", throwIfNotFound: true);
        m_Player2_HandLRRotateControl = m_Player2.FindAction("HandLRRotateControl", throwIfNotFound: true);
        m_Player2_GenerateShadowGround = m_Player2.FindAction("GenerateShadowGround", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_LampLRControl;
    private readonly InputAction m_Player1_LampTDControl;
    private readonly InputAction m_Player1_TimeRewind;
    private readonly InputAction m_Player1_Move_Walk;
    private readonly InputAction m_Player1_AbsorbShadow;
    private readonly InputAction m_Player1_ReleaseShadow;
    public struct Player1Actions
    {
        private @PlayerInput m_Wrapper;
        public Player1Actions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @LampLRControl => m_Wrapper.m_Player1_LampLRControl;
        public InputAction @LampTDControl => m_Wrapper.m_Player1_LampTDControl;
        public InputAction @TimeRewind => m_Wrapper.m_Player1_TimeRewind;
        public InputAction @Move_Walk => m_Wrapper.m_Player1_Move_Walk;
        public InputAction @AbsorbShadow => m_Wrapper.m_Player1_AbsorbShadow;
        public InputAction @ReleaseShadow => m_Wrapper.m_Player1_ReleaseShadow;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @LampLRControl.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLampLRControl;
                @LampLRControl.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLampLRControl;
                @LampLRControl.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLampLRControl;
                @LampTDControl.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLampTDControl;
                @LampTDControl.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLampTDControl;
                @LampTDControl.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnLampTDControl;
                @TimeRewind.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnTimeRewind;
                @TimeRewind.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnTimeRewind;
                @TimeRewind.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnTimeRewind;
                @Move_Walk.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove_Walk;
                @Move_Walk.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove_Walk;
                @Move_Walk.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove_Walk;
                @AbsorbShadow.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbsorbShadow;
                @AbsorbShadow.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbsorbShadow;
                @AbsorbShadow.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAbsorbShadow;
                @ReleaseShadow.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnReleaseShadow;
                @ReleaseShadow.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnReleaseShadow;
                @ReleaseShadow.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnReleaseShadow;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LampLRControl.started += instance.OnLampLRControl;
                @LampLRControl.performed += instance.OnLampLRControl;
                @LampLRControl.canceled += instance.OnLampLRControl;
                @LampTDControl.started += instance.OnLampTDControl;
                @LampTDControl.performed += instance.OnLampTDControl;
                @LampTDControl.canceled += instance.OnLampTDControl;
                @TimeRewind.started += instance.OnTimeRewind;
                @TimeRewind.performed += instance.OnTimeRewind;
                @TimeRewind.canceled += instance.OnTimeRewind;
                @Move_Walk.started += instance.OnMove_Walk;
                @Move_Walk.performed += instance.OnMove_Walk;
                @Move_Walk.canceled += instance.OnMove_Walk;
                @AbsorbShadow.started += instance.OnAbsorbShadow;
                @AbsorbShadow.performed += instance.OnAbsorbShadow;
                @AbsorbShadow.canceled += instance.OnAbsorbShadow;
                @ReleaseShadow.started += instance.OnReleaseShadow;
                @ReleaseShadow.performed += instance.OnReleaseShadow;
                @ReleaseShadow.canceled += instance.OnReleaseShadow;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Hold;
    private readonly InputAction m_Player2_HandTDControl;
    private readonly InputAction m_Player2_HandTDRotateControl;
    private readonly InputAction m_Player2_HandLRControl;
    private readonly InputAction m_Player2_HandLRRotateControl;
    private readonly InputAction m_Player2_GenerateShadowGround;
    public struct Player2Actions
    {
        private @PlayerInput m_Wrapper;
        public Player2Actions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Hold => m_Wrapper.m_Player2_Hold;
        public InputAction @HandTDControl => m_Wrapper.m_Player2_HandTDControl;
        public InputAction @HandTDRotateControl => m_Wrapper.m_Player2_HandTDRotateControl;
        public InputAction @HandLRControl => m_Wrapper.m_Player2_HandLRControl;
        public InputAction @HandLRRotateControl => m_Wrapper.m_Player2_HandLRRotateControl;
        public InputAction @GenerateShadowGround => m_Wrapper.m_Player2_GenerateShadowGround;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Hold.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHold;
                @Hold.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHold;
                @Hold.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHold;
                @HandTDControl.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandTDControl;
                @HandTDControl.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandTDControl;
                @HandTDControl.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandTDControl;
                @HandTDRotateControl.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandTDRotateControl;
                @HandTDRotateControl.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandTDRotateControl;
                @HandTDRotateControl.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandTDRotateControl;
                @HandLRControl.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandLRControl;
                @HandLRControl.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandLRControl;
                @HandLRControl.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandLRControl;
                @HandLRRotateControl.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandLRRotateControl;
                @HandLRRotateControl.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandLRRotateControl;
                @HandLRRotateControl.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnHandLRRotateControl;
                @GenerateShadowGround.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnGenerateShadowGround;
                @GenerateShadowGround.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnGenerateShadowGround;
                @GenerateShadowGround.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnGenerateShadowGround;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @HandTDControl.started += instance.OnHandTDControl;
                @HandTDControl.performed += instance.OnHandTDControl;
                @HandTDControl.canceled += instance.OnHandTDControl;
                @HandTDRotateControl.started += instance.OnHandTDRotateControl;
                @HandTDRotateControl.performed += instance.OnHandTDRotateControl;
                @HandTDRotateControl.canceled += instance.OnHandTDRotateControl;
                @HandLRControl.started += instance.OnHandLRControl;
                @HandLRControl.performed += instance.OnHandLRControl;
                @HandLRControl.canceled += instance.OnHandLRControl;
                @HandLRRotateControl.started += instance.OnHandLRRotateControl;
                @HandLRRotateControl.performed += instance.OnHandLRRotateControl;
                @HandLRRotateControl.canceled += instance.OnHandLRRotateControl;
                @GenerateShadowGround.started += instance.OnGenerateShadowGround;
                @GenerateShadowGround.performed += instance.OnGenerateShadowGround;
                @GenerateShadowGround.canceled += instance.OnGenerateShadowGround;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    public interface IPlayer1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLampLRControl(InputAction.CallbackContext context);
        void OnLampTDControl(InputAction.CallbackContext context);
        void OnTimeRewind(InputAction.CallbackContext context);
        void OnMove_Walk(InputAction.CallbackContext context);
        void OnAbsorbShadow(InputAction.CallbackContext context);
        void OnReleaseShadow(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnHold(InputAction.CallbackContext context);
        void OnHandTDControl(InputAction.CallbackContext context);
        void OnHandTDRotateControl(InputAction.CallbackContext context);
        void OnHandLRControl(InputAction.CallbackContext context);
        void OnHandLRRotateControl(InputAction.CallbackContext context);
        void OnGenerateShadowGround(InputAction.CallbackContext context);
    }
}
