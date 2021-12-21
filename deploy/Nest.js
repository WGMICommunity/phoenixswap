module.exports = async function ({ getNamedAccounts, deployments }) {
  const { deploy } = deployments

  const { deployer } = await getNamedAccounts()

  const sushi = await deployments.get("PhoenixToken")

  await deploy("Nest", {
    from: deployer,
    args: [sushi.address],
    log: true,
    deterministicDeployment: false
  })
}

module.exports.tags = ["Nest"]
module.exports.dependencies = ["UniswapV2Factory", "UniswapV2Router02", "PhoenixToken"]
