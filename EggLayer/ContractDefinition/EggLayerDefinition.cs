using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Phoenixswap.Contracts.EggLayer.ContractDefinition
{


    public partial class EggLayerDeployment : EggLayerDeploymentBase
    {
        public EggLayerDeployment() : base(BYTECODE) { }
        public EggLayerDeployment(string byteCode) : base(byteCode) { }
    }

    public class EggLayerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600060065534801561001557600080fd5b506040516117f03803806117f08339818101604052608081101561003857600080fd5b508051602082015160408301516060909301519192909160006100596100d8565b600080546001600160a01b0319166001600160a01b0383169081178255604051929350917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0908290a350600180546001600160a01b0319166001600160a01b0395909516949094179093556003919091556002919091556007556100dc565b3390565b611705806100eb6000396000f3fe608060405234801561001057600080fd5b50600436106101425760003560e01c8063630b5ba1116100b85780638da5cb5b1161007c5780638da5cb5b146103115780638dbb1e3a1461031957806393f1a40b1461033c578063b0bcf42a14610381578063e2bbb15814610389578063f2fde38b146103ac57610142565b8063630b5ba1146102a957806364482f79146102b1578063715018a6146102dc5780637e818617146102e45780638aa285501461030957610142565b80631aed65531161010a5780631aed6553146102065780631eaaa0451461020e578063441a3e701461024457806348cd4cb11461026757806351eb05a61461026f5780635312ea8e1461028c57610142565b8063081e3eda146101475780630a087903146101615780631526fe271461018557806317caf6f1146101d2578063195426ec146101da575b600080fd5b61014f6103d2565b60408051918252519081900360200190f35b6101696103d8565b604080516001600160a01b039092168252519081900360200190f35b6101a26004803603602081101561019b57600080fd5b50356103e7565b604080516001600160a01b0390951685526020850193909352838301919091526060830152519081900360800190f35b61014f610428565b61014f600480360360408110156101f057600080fd5b50803590602001356001600160a01b031661042e565b61014f6105a4565b6102426004803603606081101561022457600080fd5b508035906001600160a01b03602082013516906040013515156105aa565b005b6102426004803603604081101561025a57600080fd5b5080359060200135610733565b61014f61087a565b6102426004803603602081101561028557600080fd5b5035610880565b610242600480360360208110156102a257600080fd5b5035610a1f565b610242610aba565b610242600480360360608110156102c757600080fd5b50803590602081013590604001351515610add565b610242610bb8565b610242600480360360408110156102fa57600080fd5b50803590602001351515610c64565b61014f610cda565b610169610cdf565b61014f6004803603604081101561032f57600080fd5b5080359060200135610cee565b6103686004803603604081101561035257600080fd5b50803590602001356001600160a01b0316610d54565b6040805192835260208301919091528051918290030190f35b61014f610d78565b6102426004803603604081101561039f57600080fd5b5080359060200135610d7e565b610242600480360360208110156103c257600080fd5b50356001600160a01b0316610e83565b60045490565b6001546001600160a01b031681565b600481815481106103f457fe5b600091825260209091206004909102018054600182015460028301546003909301546001600160a01b039092169350919084565b60065481565b6000806004848154811061043e57fe5b600091825260208083208784526005825260408085206001600160a01b03898116875290845281862060049586029093016003810154815484516370a0823160e01b81523098810198909852935191985093969395939492909116926370a08231926024808301939192829003018186803b1580156104bc57600080fd5b505afa1580156104d0573d6000803e3d6000fd5b505050506040513d60208110156104e657600080fd5b50516002850154909150431180156104fd57508015155b15610569576000610512856002015443610cee565b9050600061054560065461053f886001015461053960035487610f8590919063ffffffff16565b90610f85565b90610fe5565b905061056461055d8461053f8464e8d4a51000610f85565b859061104c565b935050505b610597836001015461059164e8d4a5100061053f868860000154610f8590919063ffffffff16565b906110a6565b9450505050505b92915050565b60025481565b6105b2611103565b6001600160a01b03166105c3610cdf565b6001600160a01b03161461060c576040805162461bcd60e51b81526020600482018190526024820152600080516020611686833981519152604482015290519081900360640190fd5b801561061a5761061a610aba565b6000600754431161062d5760075461062f565b435b60065490915061063f908561104c565b600655604080516080810182526001600160a01b03948516815260208101958652908101918252600060608201818152600480546001810182559281905292517f8a35acfbc15ff81a39ae7d344fd709f28e8600b4aa8c65c6b64bfe7fe36bd19b9290930291820180546001600160a01b031916939096169290921790945593517f8a35acfbc15ff81a39ae7d344fd709f28e8600b4aa8c65c6b64bfe7fe36bd19c840155517f8a35acfbc15ff81a39ae7d344fd709f28e8600b4aa8c65c6b64bfe7fe36bd19d8301555090517f8a35acfbc15ff81a39ae7d344fd709f28e8600b4aa8c65c6b64bfe7fe36bd19e90910155565b60006004838154811061074257fe5b6000918252602080832086845260058252604080852033865290925292208054600490920290920192508311156107b5576040805162461bcd60e51b81526020600482015260126024820152711dda5d1a191c985dce881b9bdd0819dbdbd960721b604482015290519081900360640190fd5b6107be84610880565b60006107ec826001015461059164e8d4a5100061053f87600301548760000154610f8590919063ffffffff16565b90506107f83382611107565b815461080490856110a6565b80835560038401546108219164e8d4a510009161053f9190610f85565b6001830155825461083c906001600160a01b03163386611298565b604080518581529051869133917ff279e6a1f5e320cca91135676d9cb6e44ca8a08c0b88342bcdb1144f6511b5689181900360200190a35050505050565b60075481565b60006004828154811061088f57fe5b90600052602060002090600402019050806002015443116108b05750610a1c565b8054604080516370a0823160e01b815230600482015290516000926001600160a01b0316916370a08231916024808301926020929190829003018186803b1580156108fa57600080fd5b505afa15801561090e573d6000803e3d6000fd5b505050506040513d602081101561092457600080fd5b505190508061093a575043600290910155610a1c565b600061094a836002015443610cee565b9050600061097160065461053f866001015461053960035487610f8590919063ffffffff16565b600154604080516340c10f1960e01b81523060048201526024810184905290519293506001600160a01b03909116916340c10f199160448082019260009290919082900301818387803b1580156109c757600080fd5b505af11580156109db573d6000803e3d6000fd5b50505050610a096109fe8461053f64e8d4a5100085610f8590919063ffffffff16565b60038601549061104c565b6003850155505043600290920191909155505b50565b600060048281548110610a2e57fe5b60009182526020808320858452600582526040808520338087529352909320805460049093029093018054909450610a73926001600160a01b03919091169190611298565b80546040805191825251849133917fbb757047c2b5f3974fe26b7c10f732e7bce710b0952a71082702781e62ae05959181900360200190a360008082556001909101555050565b60045460005b81811015610ad957610ad181610880565b600101610ac0565b5050565b610ae5611103565b6001600160a01b0316610af6610cdf565b6001600160a01b031614610b3f576040805162461bcd60e51b81526020600482018190526024820152600080516020611686833981519152604482015290519081900360640190fd5b8015610b4d57610b4d610aba565b610b8a82610b8460048681548110610b6157fe5b9060005260206000209060040201600101546006546110a690919063ffffffff16565b9061104c565b6006819055508160048481548110610b9e57fe5b906000526020600020906004020160010181905550505050565b610bc0611103565b6001600160a01b0316610bd1610cdf565b6001600160a01b031614610c1a576040805162461bcd60e51b81526020600482018190526024820152600080516020611686833981519152604482015290519081900360640190fd5b600080546040516001600160a01b03909116907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0908390a3600080546001600160a01b0319169055565b610c6c611103565b6001600160a01b0316610c7d610cdf565b6001600160a01b031614610cc6576040805162461bcd60e51b81526020600482018190526024820152600080516020611686833981519152604482015290519081900360640190fd5b8015610cd457610cd4610aba565b50600355565b600a81565b6000546001600160a01b031690565b60006002548211610d0f57610d08600a61053984866110a6565b905061059e565b6002548310610d2257610d0882846110a6565b610d08610d3a600254846110a690919063ffffffff16565b610b84600a610539876002546110a690919063ffffffff16565b60056020908152600092835260408084209091529082529020805460019091015482565b60035481565b600060048381548110610d8d57fe5b60009182526020808320868452600582526040808520338652909252922060049091029091019150610dbe84610880565b805415610e01576000610df3826001015461059164e8d4a5100061053f87600301548760000154610f8590919063ffffffff16565b9050610dff3382611107565b505b8154610e18906001600160a01b03163330866112ea565b8054610e24908461104c565b8082556003830154610e419164e8d4a510009161053f9190610f85565b6001820155604080518481529051859133917f90890809c654f11d6e72a28fa60149770a0d11ec6c92319d6ceb2bb0a4ea1a159181900360200190a350505050565b610e8b611103565b6001600160a01b0316610e9c610cdf565b6001600160a01b031614610ee5576040805162461bcd60e51b81526020600482018190526024820152600080516020611686833981519152604482015290519081900360640190fd5b6001600160a01b038116610f2a5760405162461bcd60e51b81526004018080602001828103825260268152602001806116196026913960400191505060405180910390fd5b600080546040516001600160a01b03808516939216917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e091a3600080546001600160a01b0319166001600160a01b0392909216919091179055565b600082610f945750600061059e565b82820282848281610fa157fe5b0414610fde5760405162461bcd60e51b81526004018080602001828103825260218152602001806116656021913960400191505060405180910390fd5b9392505050565b600080821161103b576040805162461bcd60e51b815260206004820152601a60248201527f536166654d6174683a206469766973696f6e206279207a65726f000000000000604482015290519081900360640190fd5b81838161104457fe5b049392505050565b600082820183811015610fde576040805162461bcd60e51b815260206004820152601b60248201527f536166654d6174683a206164646974696f6e206f766572666c6f770000000000604482015290519081900360640190fd5b6000828211156110fd576040805162461bcd60e51b815260206004820152601e60248201527f536166654d6174683a207375627472616374696f6e206f766572666c6f770000604482015290519081900360640190fd5b50900390565b3390565b600154604080516370a0823160e01b815230600482015290516000926001600160a01b0316916370a08231916024808301926020929190829003018186803b15801561115257600080fd5b505afa158015611166573d6000803e3d6000fd5b505050506040513d602081101561117c57600080fd5b5051905080821115611210576001546040805163a9059cbb60e01b81526001600160a01b038681166004830152602482018590529151919092169163a9059cbb9160448083019260209291908290030181600087803b1580156111de57600080fd5b505af11580156111f2573d6000803e3d6000fd5b505050506040513d602081101561120857600080fd5b506112939050565b6001546040805163a9059cbb60e01b81526001600160a01b038681166004830152602482018690529151919092169163a9059cbb9160448083019260209291908290030181600087803b15801561126657600080fd5b505af115801561127a573d6000803e3d6000fd5b505050506040513d602081101561129057600080fd5b50505b505050565b604080516001600160a01b038416602482015260448082018490528251808303909101815260649091019091526020810180516001600160e01b031663a9059cbb60e01b17905261129390849061134a565b604080516001600160a01b0380861660248301528416604482015260648082018490528251808303909101815260849091019091526020810180516001600160e01b03166323b872dd60e01b17905261134490859061134a565b50505050565b606061139f826040518060400160405280602081526020017f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c6564815250856001600160a01b03166113fb9092919063ffffffff16565b805190915015611293578080602001905160208110156113be57600080fd5b50516112935760405162461bcd60e51b815260040180806020018281038252602a8152602001806116a6602a913960400191505060405180910390fd5b606061140a8484600085611412565b949350505050565b6060824710156114535760405162461bcd60e51b815260040180806020018281038252602681526020018061163f6026913960400191505060405180910390fd5b61145c8561156e565b6114ad576040805162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e7472616374000000604482015290519081900360640190fd5b60006060866001600160a01b031685876040518082805190602001908083835b602083106114ec5780518252601f1990920191602091820191016114cd565b6001836020036101000a03801982511681845116808217855250505050505090500191505060006040518083038185875af1925050503d806000811461154e576040519150601f19603f3d011682016040523d82523d6000602084013e611553565b606091505b5091509150611563828286611574565b979650505050505050565b3b151590565b60608315611583575081610fde565b8251156115935782518084602001fd5b8160405162461bcd60e51b81526004018080602001828103825283818151815260200191508051906020019080838360005b838110156115dd5781810151838201526020016115c5565b50505050905090810190601f16801561160a5780820380516001836020036101000a031916815260200191505b509250505060405180910390fdfe4f776e61626c653a206e6577206f776e657220697320746865207a65726f2061646472657373416464726573733a20696e73756666696369656e742062616c616e636520666f722063616c6c536166654d6174683a206d756c7469706c69636174696f6e206f766572666c6f774f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e65725361666545524332303a204552433230206f7065726174696f6e20646964206e6f742073756363656564a264697066735822122057e962267ee7931227f1b9cff0182ab2943dad3e354a4bafa0b8ee2f586789c164736f6c634300060c0033";
        public EggLayerDeploymentBase() : base(BYTECODE) { }
        public EggLayerDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_sushi", 1)]
        public virtual string Sushi { get; set; }
        [Parameter("uint256", "_sushiPerBlock", 2)]
        public virtual BigInteger SushiPerBlock { get; set; }
        [Parameter("uint256", "_startBlock", 3)]
        public virtual BigInteger StartBlock { get; set; }
        [Parameter("uint256", "_bonusEndBlock", 4)]
        public virtual BigInteger BonusEndBlock { get; set; }
    }

    public partial class BONUS_MULTIPLIERFunction : BONUS_MULTIPLIERFunctionBase { }

    [Function("BONUS_MULTIPLIER", "uint256")]
    public class BONUS_MULTIPLIERFunctionBase : FunctionMessage
    {

    }

    public partial class AddFunction : AddFunctionBase { }

    [Function("add")]
    public class AddFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_allocPoint", 1)]
        public virtual BigInteger AllocPoint { get; set; }
        [Parameter("address", "_lpToken", 2)]
        public virtual string LpToken { get; set; }
        [Parameter("bool", "_withUpdate", 3)]
        public virtual bool WithUpdate { get; set; }
    }

    public partial class BonusEndBlockFunction : BonusEndBlockFunctionBase { }

    [Function("bonusEndBlock", "uint256")]
    public class BonusEndBlockFunctionBase : FunctionMessage
    {

    }

    public partial class DepositFunction : DepositFunctionBase { }

    [Function("deposit")]
    public class DepositFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_pid", 1)]
        public virtual BigInteger Pid { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class EmergencyWithdrawFunction : EmergencyWithdrawFunctionBase { }

    [Function("emergencyWithdraw")]
    public class EmergencyWithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_pid", 1)]
        public virtual BigInteger Pid { get; set; }
    }

    public partial class GetMultiplierFunction : GetMultiplierFunctionBase { }

    [Function("getMultiplier", "uint256")]
    public class GetMultiplierFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_from", 1)]
        public virtual BigInteger From { get; set; }
        [Parameter("uint256", "_to", 2)]
        public virtual BigInteger To { get; set; }
    }

    public partial class MassUpdatePoolsFunction : MassUpdatePoolsFunctionBase { }

    [Function("massUpdatePools")]
    public class MassUpdatePoolsFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PendingSushiFunction : PendingSushiFunctionBase { }

    [Function("pendingSushi", "uint256")]
    public class PendingSushiFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_pid", 1)]
        public virtual BigInteger Pid { get; set; }
        [Parameter("address", "_user", 2)]
        public virtual string User { get; set; }
    }

    public partial class PoolInfoFunction : PoolInfoFunctionBase { }

    [Function("poolInfo", typeof(PoolInfoOutputDTO))]
    public class PoolInfoFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PoolLengthFunction : PoolLengthFunctionBase { }

    [Function("poolLength", "uint256")]
    public class PoolLengthFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SetFunction : SetFunctionBase { }

    [Function("set")]
    public class SetFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_pid", 1)]
        public virtual BigInteger Pid { get; set; }
        [Parameter("uint256", "_allocPoint", 2)]
        public virtual BigInteger AllocPoint { get; set; }
        [Parameter("bool", "_withUpdate", 3)]
        public virtual bool WithUpdate { get; set; }
    }

    public partial class SetMintRateFunction : SetMintRateFunctionBase { }

    [Function("setMintRate")]
    public class SetMintRateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_sushiPerBlock", 1)]
        public virtual BigInteger SushiPerBlock { get; set; }
        [Parameter("bool", "_withUpdate", 2)]
        public virtual bool WithUpdate { get; set; }
    }

    public partial class StartBlockFunction : StartBlockFunctionBase { }

    [Function("startBlock", "uint256")]
    public class StartBlockFunctionBase : FunctionMessage
    {

    }

    public partial class SushiFunction : SushiFunctionBase { }

    [Function("sushi", "address")]
    public class SushiFunctionBase : FunctionMessage
    {

    }

    public partial class SushiPerBlockFunction : SushiPerBlockFunctionBase { }

    [Function("sushiPerBlock", "uint256")]
    public class SushiPerBlockFunctionBase : FunctionMessage
    {

    }

    public partial class TotalAllocPointFunction : TotalAllocPointFunctionBase { }

    [Function("totalAllocPoint", "uint256")]
    public class TotalAllocPointFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class UpdatePoolFunction : UpdatePoolFunctionBase { }

    [Function("updatePool")]
    public class UpdatePoolFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_pid", 1)]
        public virtual BigInteger Pid { get; set; }
    }

    public partial class UserInfoFunction : UserInfoFunctionBase { }

    [Function("userInfo", typeof(UserInfoOutputDTO))]
    public class UserInfoFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_pid", 1)]
        public virtual BigInteger Pid { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DepositEventDTO : DepositEventDTOBase { }

    [Event("Deposit")]
    public class DepositEventDTOBase : IEventDTO
    {
        [Parameter("address", "user", 1, true )]
        public virtual string User { get; set; }
        [Parameter("uint256", "pid", 2, true )]
        public virtual BigInteger Pid { get; set; }
        [Parameter("uint256", "amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class EmergencyWithdrawEventDTO : EmergencyWithdrawEventDTOBase { }

    [Event("EmergencyWithdraw")]
    public class EmergencyWithdrawEventDTOBase : IEventDTO
    {
        [Parameter("address", "user", 1, true )]
        public virtual string User { get; set; }
        [Parameter("uint256", "pid", 2, true )]
        public virtual BigInteger Pid { get; set; }
        [Parameter("uint256", "amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class WithdrawEventDTO : WithdrawEventDTOBase { }

    [Event("Withdraw")]
    public class WithdrawEventDTOBase : IEventDTO
    {
        [Parameter("address", "user", 1, true )]
        public virtual string User { get; set; }
        [Parameter("uint256", "pid", 2, true )]
        public virtual BigInteger Pid { get; set; }
        [Parameter("uint256", "amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BONUS_MULTIPLIEROutputDTO : BONUS_MULTIPLIEROutputDTOBase { }

    [FunctionOutput]
    public class BONUS_MULTIPLIEROutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BonusEndBlockOutputDTO : BonusEndBlockOutputDTOBase { }

    [FunctionOutput]
    public class BonusEndBlockOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class GetMultiplierOutputDTO : GetMultiplierOutputDTOBase { }

    [FunctionOutput]
    public class GetMultiplierOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PendingSushiOutputDTO : PendingSushiOutputDTOBase { }

    [FunctionOutput]
    public class PendingSushiOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PoolInfoOutputDTO : PoolInfoOutputDTOBase { }

    [FunctionOutput]
    public class PoolInfoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "lpToken", 1)]
        public virtual string LpToken { get; set; }
        [Parameter("uint256", "allocPoint", 2)]
        public virtual BigInteger AllocPoint { get; set; }
        [Parameter("uint256", "lastRewardBlock", 3)]
        public virtual BigInteger LastRewardBlock { get; set; }
        [Parameter("uint256", "accSushiPerShare", 4)]
        public virtual BigInteger AccSushiPerShare { get; set; }
    }

    public partial class PoolLengthOutputDTO : PoolLengthOutputDTOBase { }

    [FunctionOutput]
    public class PoolLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }







    public partial class StartBlockOutputDTO : StartBlockOutputDTOBase { }

    [FunctionOutput]
    public class StartBlockOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SushiOutputDTO : SushiOutputDTOBase { }

    [FunctionOutput]
    public class SushiOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SushiPerBlockOutputDTO : SushiPerBlockOutputDTOBase { }

    [FunctionOutput]
    public class SushiPerBlockOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TotalAllocPointOutputDTO : TotalAllocPointOutputDTOBase { }

    [FunctionOutput]
    public class TotalAllocPointOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class UserInfoOutputDTO : UserInfoOutputDTOBase { }

    [FunctionOutput]
    public class UserInfoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint256", "rewardDebt", 2)]
        public virtual BigInteger RewardDebt { get; set; }
    }


}
