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
using Phoenixswap.Contracts.EggMaker.ContractDefinition;

namespace Phoenixswap.Contracts.EggMaker
{
    public partial class EggMakerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, EggMakerDeployment eggMakerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<EggMakerDeployment>().SendRequestAndWaitForReceiptAsync(eggMakerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, EggMakerDeployment eggMakerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EggMakerDeployment>().SendRequestAsync(eggMakerDeployment);
        }

        public static async Task<EggMakerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, EggMakerDeployment eggMakerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eggMakerDeployment, cancellationTokenSource);
            return new EggMakerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public EggMakerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BarQueryAsync(BarFunction barFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BarFunction, string>(barFunction, blockParameter);
        }

        
        public Task<string> BarQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BarFunction, string>(null, blockParameter);
        }

        public Task<string> BridgeForQueryAsync(BridgeForFunction bridgeForFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BridgeForFunction, string>(bridgeForFunction, blockParameter);
        }

        
        public Task<string> BridgeForQueryAsync(string token, BlockParameter blockParameter = null)
        {
            var bridgeForFunction = new BridgeForFunction();
                bridgeForFunction.Token = token;
            
            return ContractHandler.QueryAsync<BridgeForFunction, string>(bridgeForFunction, blockParameter);
        }

        public Task<string> ClaimOwnershipRequestAsync(ClaimOwnershipFunction claimOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(claimOwnershipFunction);
        }

        public Task<string> ClaimOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ClaimOwnershipFunction>();
        }

        public Task<TransactionReceipt> ClaimOwnershipRequestAndWaitForReceiptAsync(ClaimOwnershipFunction claimOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ClaimOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ClaimOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> ConvertRequestAsync(ConvertFunction convertFunction)
        {
             return ContractHandler.SendRequestAsync(convertFunction);
        }

        public Task<TransactionReceipt> ConvertRequestAndWaitForReceiptAsync(ConvertFunction convertFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(convertFunction, cancellationToken);
        }

        public Task<string> ConvertRequestAsync(string token0, string token1)
        {
            var convertFunction = new ConvertFunction();
                convertFunction.Token0 = token0;
                convertFunction.Token1 = token1;
            
             return ContractHandler.SendRequestAsync(convertFunction);
        }

        public Task<TransactionReceipt> ConvertRequestAndWaitForReceiptAsync(string token0, string token1, CancellationTokenSource cancellationToken = null)
        {
            var convertFunction = new ConvertFunction();
                convertFunction.Token0 = token0;
                convertFunction.Token1 = token1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(convertFunction, cancellationToken);
        }

        public Task<string> ConvertMultipleRequestAsync(ConvertMultipleFunction convertMultipleFunction)
        {
             return ContractHandler.SendRequestAsync(convertMultipleFunction);
        }

        public Task<TransactionReceipt> ConvertMultipleRequestAndWaitForReceiptAsync(ConvertMultipleFunction convertMultipleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(convertMultipleFunction, cancellationToken);
        }

        public Task<string> ConvertMultipleRequestAsync(List<string> token0, List<string> token1)
        {
            var convertMultipleFunction = new ConvertMultipleFunction();
                convertMultipleFunction.Token0 = token0;
                convertMultipleFunction.Token1 = token1;
            
             return ContractHandler.SendRequestAsync(convertMultipleFunction);
        }

        public Task<TransactionReceipt> ConvertMultipleRequestAndWaitForReceiptAsync(List<string> token0, List<string> token1, CancellationTokenSource cancellationToken = null)
        {
            var convertMultipleFunction = new ConvertMultipleFunction();
                convertMultipleFunction.Token0 = token0;
                convertMultipleFunction.Token1 = token1;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(convertMultipleFunction, cancellationToken);
        }

        public Task<string> FactoryQueryAsync(FactoryFunction factoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(factoryFunction, blockParameter);
        }

        
        public Task<string> FactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> PendingOwnerQueryAsync(PendingOwnerFunction pendingOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingOwnerFunction, string>(pendingOwnerFunction, blockParameter);
        }

        
        public Task<string> PendingOwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingOwnerFunction, string>(null, blockParameter);
        }

        public Task<string> SetBridgeRequestAsync(SetBridgeFunction setBridgeFunction)
        {
             return ContractHandler.SendRequestAsync(setBridgeFunction);
        }

        public Task<TransactionReceipt> SetBridgeRequestAndWaitForReceiptAsync(SetBridgeFunction setBridgeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBridgeFunction, cancellationToken);
        }

        public Task<string> SetBridgeRequestAsync(string token, string bridge)
        {
            var setBridgeFunction = new SetBridgeFunction();
                setBridgeFunction.Token = token;
                setBridgeFunction.Bridge = bridge;
            
             return ContractHandler.SendRequestAsync(setBridgeFunction);
        }

        public Task<TransactionReceipt> SetBridgeRequestAndWaitForReceiptAsync(string token, string bridge, CancellationTokenSource cancellationToken = null)
        {
            var setBridgeFunction = new SetBridgeFunction();
                setBridgeFunction.Token = token;
                setBridgeFunction.Bridge = bridge;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBridgeFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner, bool direct, bool renounce)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
                transferOwnershipFunction.Direct = direct;
                transferOwnershipFunction.Renounce = renounce;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, bool direct, bool renounce, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
                transferOwnershipFunction.Direct = direct;
                transferOwnershipFunction.Renounce = renounce;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }
    }
}
