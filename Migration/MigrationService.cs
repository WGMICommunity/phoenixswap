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
using Phoenixswap.Contracts.Migration.ContractDefinition;

namespace Phoenixswap.Contracts.Migration
{
    public partial class MigrationService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MigrationDeployment migrationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MigrationDeployment>().SendRequestAndWaitForReceiptAsync(migrationDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MigrationDeployment migrationDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MigrationDeployment>().SendRequestAsync(migrationDeployment);
        }

        public static async Task<MigrationService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MigrationDeployment migrationDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, migrationDeployment, cancellationTokenSource);
            return new MigrationService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MigrationService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> MigrateRequestAsync(MigrateFunction migrateFunction)
        {
             return ContractHandler.SendRequestAsync(migrateFunction);
        }

        public Task<TransactionReceipt> MigrateRequestAndWaitForReceiptAsync(MigrateFunction migrateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(migrateFunction, cancellationToken);
        }

        public Task<string> MigrateRequestAsync(string tokenA, string tokenB, BigInteger liquidity, BigInteger amountAMin, BigInteger amountBMin, BigInteger deadline)
        {
            var migrateFunction = new MigrateFunction();
                migrateFunction.TokenA = tokenA;
                migrateFunction.TokenB = tokenB;
                migrateFunction.Liquidity = liquidity;
                migrateFunction.AmountAMin = amountAMin;
                migrateFunction.AmountBMin = amountBMin;
                migrateFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAsync(migrateFunction);
        }

        public Task<TransactionReceipt> MigrateRequestAndWaitForReceiptAsync(string tokenA, string tokenB, BigInteger liquidity, BigInteger amountAMin, BigInteger amountBMin, BigInteger deadline, CancellationTokenSource cancellationToken = null)
        {
            var migrateFunction = new MigrateFunction();
                migrateFunction.TokenA = tokenA;
                migrateFunction.TokenB = tokenB;
                migrateFunction.Liquidity = liquidity;
                migrateFunction.AmountAMin = amountAMin;
                migrateFunction.AmountBMin = amountBMin;
                migrateFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(migrateFunction, cancellationToken);
        }

        public Task<string> MigrateWithPermitRequestAsync(MigrateWithPermitFunction migrateWithPermitFunction)
        {
             return ContractHandler.SendRequestAsync(migrateWithPermitFunction);
        }

        public Task<TransactionReceipt> MigrateWithPermitRequestAndWaitForReceiptAsync(MigrateWithPermitFunction migrateWithPermitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(migrateWithPermitFunction, cancellationToken);
        }

        public Task<string> MigrateWithPermitRequestAsync(string tokenA, string tokenB, BigInteger liquidity, BigInteger amountAMin, BigInteger amountBMin, BigInteger deadline, byte v, byte[] r, byte[] s)
        {
            var migrateWithPermitFunction = new MigrateWithPermitFunction();
                migrateWithPermitFunction.TokenA = tokenA;
                migrateWithPermitFunction.TokenB = tokenB;
                migrateWithPermitFunction.Liquidity = liquidity;
                migrateWithPermitFunction.AmountAMin = amountAMin;
                migrateWithPermitFunction.AmountBMin = amountBMin;
                migrateWithPermitFunction.Deadline = deadline;
                migrateWithPermitFunction.V = v;
                migrateWithPermitFunction.R = r;
                migrateWithPermitFunction.S = s;
            
             return ContractHandler.SendRequestAsync(migrateWithPermitFunction);
        }

        public Task<TransactionReceipt> MigrateWithPermitRequestAndWaitForReceiptAsync(string tokenA, string tokenB, BigInteger liquidity, BigInteger amountAMin, BigInteger amountBMin, BigInteger deadline, byte v, byte[] r, byte[] s, CancellationTokenSource cancellationToken = null)
        {
            var migrateWithPermitFunction = new MigrateWithPermitFunction();
                migrateWithPermitFunction.TokenA = tokenA;
                migrateWithPermitFunction.TokenB = tokenB;
                migrateWithPermitFunction.Liquidity = liquidity;
                migrateWithPermitFunction.AmountAMin = amountAMin;
                migrateWithPermitFunction.AmountBMin = amountBMin;
                migrateWithPermitFunction.Deadline = deadline;
                migrateWithPermitFunction.V = v;
                migrateWithPermitFunction.R = r;
                migrateWithPermitFunction.S = s;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(migrateWithPermitFunction, cancellationToken);
        }

        public Task<string> OldRouterQueryAsync(OldRouterFunction oldRouterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OldRouterFunction, string>(oldRouterFunction, blockParameter);
        }

        
        public Task<string> OldRouterQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OldRouterFunction, string>(null, blockParameter);
        }

        public Task<string> RouterQueryAsync(RouterFunction routerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RouterFunction, string>(routerFunction, blockParameter);
        }

        
        public Task<string> RouterQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RouterFunction, string>(null, blockParameter);
        }
    }
}
