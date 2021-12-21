using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Phoenixswap.Contracts.EggLayer.ContractDefinition;

namespace Phoenixswap.Contracts.EggLayer
{
    public partial class EggLayerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, EggLayerDeployment eggLayerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<EggLayerDeployment>().SendRequestAndWaitForReceiptAsync(eggLayerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, EggLayerDeployment eggLayerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EggLayerDeployment>().SendRequestAsync(eggLayerDeployment);
        }

        public static async Task<EggLayerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, EggLayerDeployment eggLayerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eggLayerDeployment, cancellationTokenSource);
            return new EggLayerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public EggLayerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> BONUS_MULTIPLIERQueryAsync(BONUS_MULTIPLIERFunction bONUS_MULTIPLIERFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BONUS_MULTIPLIERFunction, BigInteger>(bONUS_MULTIPLIERFunction, blockParameter);
        }

        
        public Task<BigInteger> BONUS_MULTIPLIERQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BONUS_MULTIPLIERFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AddRequestAsync(AddFunction addFunction)
        {
             return ContractHandler.SendRequestAsync(addFunction);
        }

        public Task<TransactionReceipt> AddRequestAndWaitForReceiptAsync(AddFunction addFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addFunction, cancellationToken);
        }

        public Task<string> AddRequestAsync(BigInteger allocPoint, string lpToken, bool withUpdate)
        {
            var addFunction = new AddFunction();
                addFunction.AllocPoint = allocPoint;
                addFunction.LpToken = lpToken;
                addFunction.WithUpdate = withUpdate;
            
             return ContractHandler.SendRequestAsync(addFunction);
        }

        public Task<TransactionReceipt> AddRequestAndWaitForReceiptAsync(BigInteger allocPoint, string lpToken, bool withUpdate, CancellationTokenSource cancellationToken = null)
        {
            var addFunction = new AddFunction();
                addFunction.AllocPoint = allocPoint;
                addFunction.LpToken = lpToken;
                addFunction.WithUpdate = withUpdate;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addFunction, cancellationToken);
        }

        public Task<BigInteger> BonusEndBlockQueryAsync(BonusEndBlockFunction bonusEndBlockFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BonusEndBlockFunction, BigInteger>(bonusEndBlockFunction, blockParameter);
        }

        
        public Task<BigInteger> BonusEndBlockQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BonusEndBlockFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> DepositRequestAsync(DepositFunction depositFunction)
        {
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(DepositFunction depositFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> DepositRequestAsync(BigInteger pid, BigInteger amount)
        {
            var depositFunction = new DepositFunction();
                depositFunction.Pid = pid;
                depositFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(BigInteger pid, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var depositFunction = new DepositFunction();
                depositFunction.Pid = pid;
                depositFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> EmergencyWithdrawRequestAsync(EmergencyWithdrawFunction emergencyWithdrawFunction)
        {
             return ContractHandler.SendRequestAsync(emergencyWithdrawFunction);
        }

        public Task<TransactionReceipt> EmergencyWithdrawRequestAndWaitForReceiptAsync(EmergencyWithdrawFunction emergencyWithdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(emergencyWithdrawFunction, cancellationToken);
        }

        public Task<string> EmergencyWithdrawRequestAsync(BigInteger pid)
        {
            var emergencyWithdrawFunction = new EmergencyWithdrawFunction();
                emergencyWithdrawFunction.Pid = pid;
            
             return ContractHandler.SendRequestAsync(emergencyWithdrawFunction);
        }

        public Task<TransactionReceipt> EmergencyWithdrawRequestAndWaitForReceiptAsync(BigInteger pid, CancellationTokenSource cancellationToken = null)
        {
            var emergencyWithdrawFunction = new EmergencyWithdrawFunction();
                emergencyWithdrawFunction.Pid = pid;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(emergencyWithdrawFunction, cancellationToken);
        }

        public Task<BigInteger> GetMultiplierQueryAsync(GetMultiplierFunction getMultiplierFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMultiplierFunction, BigInteger>(getMultiplierFunction, blockParameter);
        }

        
        public Task<BigInteger> GetMultiplierQueryAsync(BigInteger from, BigInteger to, BlockParameter blockParameter = null)
        {
            var getMultiplierFunction = new GetMultiplierFunction();
                getMultiplierFunction.From = from;
                getMultiplierFunction.To = to;
            
            return ContractHandler.QueryAsync<GetMultiplierFunction, BigInteger>(getMultiplierFunction, blockParameter);
        }

        public Task<string> MassUpdatePoolsRequestAsync(MassUpdatePoolsFunction massUpdatePoolsFunction)
        {
             return ContractHandler.SendRequestAsync(massUpdatePoolsFunction);
        }

        public Task<string> MassUpdatePoolsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<MassUpdatePoolsFunction>();
        }

        public Task<TransactionReceipt> MassUpdatePoolsRequestAndWaitForReceiptAsync(MassUpdatePoolsFunction massUpdatePoolsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(massUpdatePoolsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> MassUpdatePoolsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<MassUpdatePoolsFunction>(null, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> PendingSushiQueryAsync(PendingSushiFunction pendingSushiFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingSushiFunction, BigInteger>(pendingSushiFunction, blockParameter);
        }

        
        public Task<BigInteger> PendingSushiQueryAsync(BigInteger pid, string user, BlockParameter blockParameter = null)
        {
            var pendingSushiFunction = new PendingSushiFunction();
                pendingSushiFunction.Pid = pid;
                pendingSushiFunction.User = user;
            
            return ContractHandler.QueryAsync<PendingSushiFunction, BigInteger>(pendingSushiFunction, blockParameter);
        }

        public Task<PoolInfoOutputDTO> PoolInfoQueryAsync(PoolInfoFunction poolInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PoolInfoFunction, PoolInfoOutputDTO>(poolInfoFunction, blockParameter);
        }

        public Task<PoolInfoOutputDTO> PoolInfoQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var poolInfoFunction = new PoolInfoFunction();
                poolInfoFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PoolInfoFunction, PoolInfoOutputDTO>(poolInfoFunction, blockParameter);
        }

        public Task<BigInteger> PoolLengthQueryAsync(PoolLengthFunction poolLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoolLengthFunction, BigInteger>(poolLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> PoolLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoolLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SetRequestAsync(SetFunction setFunction)
        {
             return ContractHandler.SendRequestAsync(setFunction);
        }

        public Task<TransactionReceipt> SetRequestAndWaitForReceiptAsync(SetFunction setFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFunction, cancellationToken);
        }

        public Task<string> SetRequestAsync(BigInteger pid, BigInteger allocPoint, bool withUpdate)
        {
            var setFunction = new SetFunction();
                setFunction.Pid = pid;
                setFunction.AllocPoint = allocPoint;
                setFunction.WithUpdate = withUpdate;
            
             return ContractHandler.SendRequestAsync(setFunction);
        }

        public Task<TransactionReceipt> SetRequestAndWaitForReceiptAsync(BigInteger pid, BigInteger allocPoint, bool withUpdate, CancellationTokenSource cancellationToken = null)
        {
            var setFunction = new SetFunction();
                setFunction.Pid = pid;
                setFunction.AllocPoint = allocPoint;
                setFunction.WithUpdate = withUpdate;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFunction, cancellationToken);
        }

        public Task<string> SetMintRateRequestAsync(SetMintRateFunction setMintRateFunction)
        {
             return ContractHandler.SendRequestAsync(setMintRateFunction);
        }

        public Task<TransactionReceipt> SetMintRateRequestAndWaitForReceiptAsync(SetMintRateFunction setMintRateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMintRateFunction, cancellationToken);
        }

        public Task<string> SetMintRateRequestAsync(BigInteger sushiPerBlock, bool withUpdate)
        {
            var setMintRateFunction = new SetMintRateFunction();
                setMintRateFunction.SushiPerBlock = sushiPerBlock;
                setMintRateFunction.WithUpdate = withUpdate;
            
             return ContractHandler.SendRequestAsync(setMintRateFunction);
        }

        public Task<TransactionReceipt> SetMintRateRequestAndWaitForReceiptAsync(BigInteger sushiPerBlock, bool withUpdate, CancellationTokenSource cancellationToken = null)
        {
            var setMintRateFunction = new SetMintRateFunction();
                setMintRateFunction.SushiPerBlock = sushiPerBlock;
                setMintRateFunction.WithUpdate = withUpdate;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMintRateFunction, cancellationToken);
        }

        public Task<BigInteger> StartBlockQueryAsync(StartBlockFunction startBlockFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StartBlockFunction, BigInteger>(startBlockFunction, blockParameter);
        }

        
        public Task<BigInteger> StartBlockQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StartBlockFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SushiQueryAsync(SushiFunction sushiFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SushiFunction, string>(sushiFunction, blockParameter);
        }

        
        public Task<string> SushiQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SushiFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> SushiPerBlockQueryAsync(SushiPerBlockFunction sushiPerBlockFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SushiPerBlockFunction, BigInteger>(sushiPerBlockFunction, blockParameter);
        }

        
        public Task<BigInteger> SushiPerBlockQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SushiPerBlockFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> TotalAllocPointQueryAsync(TotalAllocPointFunction totalAllocPointFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalAllocPointFunction, BigInteger>(totalAllocPointFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalAllocPointQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalAllocPointFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> UpdatePoolRequestAsync(UpdatePoolFunction updatePoolFunction)
        {
             return ContractHandler.SendRequestAsync(updatePoolFunction);
        }

        public Task<TransactionReceipt> UpdatePoolRequestAndWaitForReceiptAsync(UpdatePoolFunction updatePoolFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updatePoolFunction, cancellationToken);
        }

        public Task<string> UpdatePoolRequestAsync(BigInteger pid)
        {
            var updatePoolFunction = new UpdatePoolFunction();
                updatePoolFunction.Pid = pid;
            
             return ContractHandler.SendRequestAsync(updatePoolFunction);
        }

        public Task<TransactionReceipt> UpdatePoolRequestAndWaitForReceiptAsync(BigInteger pid, CancellationTokenSource cancellationToken = null)
        {
            var updatePoolFunction = new UpdatePoolFunction();
                updatePoolFunction.Pid = pid;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updatePoolFunction, cancellationToken);
        }

        public Task<UserInfoOutputDTO> UserInfoQueryAsync(UserInfoFunction userInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<UserInfoFunction, UserInfoOutputDTO>(userInfoFunction, blockParameter);
        }

        public Task<UserInfoOutputDTO> UserInfoQueryAsync(BigInteger returnValue1, string returnValue2, BlockParameter blockParameter = null)
        {
            var userInfoFunction = new UserInfoFunction();
                userInfoFunction.ReturnValue1 = returnValue1;
                userInfoFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryDeserializingToObjectAsync<UserInfoFunction, UserInfoOutputDTO>(userInfoFunction, blockParameter);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger pid, BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Pid = pid;
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger pid, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Pid = pid;
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }
    }
}
