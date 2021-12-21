// SPDX-License-Identifier: MIT

pragma solidity 0.6.12;

import "@openzeppelin/contracts/token/ERC20/IERC20.sol";
import "@openzeppelin/contracts/token/ERC20/ERC20.sol";
import "@openzeppelin/contracts/math/SafeMath.sol";

// Nest is the coolest bar in town. You come in with some Phoenix, and leave with more! The longer you stay, the more Phoenix you get.
//
// This contract handles swapping to and from xPhoenix, Phoenixswap's staking token.
contract Nest is ERC20("Nest", "xPHX"){
    using SafeMath for uint256;
    IERC20 public sushi;

    // Define the Phoenix token contract
    constructor(IERC20 _sushi) public {
        sushi = _sushi;
    }

    // Enter the bar. Pay some SUSHIs. Earn some shares.
    // Locks Phoenix and mints xPhoenix
    function enter(uint256 _amount) public {
        // Gets the amount of Phoenix locked in the contract
        uint256 totalSushi = sushi.balanceOf(address(this));
        // Gets the amount of xPhoenix in existence
        uint256 totalShares = totalSupply();
        // If no xPhoenix exists, mint it 1:1 to the amount put in
        if (totalShares == 0 || totalSushi == 0) {
            _mint(msg.sender, _amount);
        } 
        // Calculate and mint the amount of xPhoenix the Phoenix is worth. The ratio will change overtime, as xPhoenix is burned/minted and Phoenix deposited + gained from fees / withdrawn.
        else {
            uint256 what = _amount.mul(totalShares).div(totalSushi);
            _mint(msg.sender, what);
        }
        // Lock the Phoenix in the contract
        sushi.transferFrom(msg.sender, address(this), _amount);
    }

    // Leave the bar. Claim back your Phoenix'.
    // Unlocks the staked + gained Phoenix and burns xPhoenix
    function leave(uint256 _share) public {
        // Gets the amount of xPhoenix in existence
        uint256 totalShares = totalSupply();
        // Calculates the amount of Phoenix the xPhoenix is worth
        uint256 what = _share.mul(sushi.balanceOf(address(this))).div(totalShares);
        _burn(msg.sender, _share);
        sushi.transfer(msg.sender, what);
    }
}
