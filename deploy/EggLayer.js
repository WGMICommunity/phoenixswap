module.exports = async function ({ ethers, deployments, getNamedAccounts }) {
  const { deploy } = deployments

  const { deployer, dev } = await getNamedAccounts()

  const sushi = await ethers.getContract("PhoenixToken")
  
  const { address } = await deploy("EggLayer", {
    from: deployer,
    args: [sushi.address, "1000000000000000000000", "0", "1000000000000000000000"],
    log: true,
    deterministicDeployment: false
  })

  if (await sushi.owner() !== address) {
    // Transfer Phoenix Ownership to Layer
    console.log("Transfer Phoenix Ownership to Layer")
    await (await sushi.transferOwnership(address)).wait()
  }

  /*const masterChef = await ethers.getContract("EggLayer")
  if (await masterChef.owner() !== dev) {
    // Transfer ownership of EggLayer to dev
    console.log("Transfer ownership of EggLayer to dev")
    await (await masterChef.transferOwnership(dev)).wait()
  }*/
}

module.exports.tags = ["EggLayer"]
module.exports.dependencies = ["UniswapV2Factory", "UniswapV2Router02", "PhoenixToken"]
