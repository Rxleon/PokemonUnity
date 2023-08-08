﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonUnity;
using PokemonUnity.UX;
using PokemonUnity.Combat;
using PokemonUnity.Character;
using PokemonUnity.Inventory;
using PokemonEssentials.Interface;
using PokemonEssentials.Interface.Battle;
using PokemonEssentials.Interface.Field;
using PokemonEssentials.Interface.Item;
using PokemonEssentials.Interface.PokeBattle;
using PokemonEssentials.Interface.PokeBattle.Effects;
using PokemonEssentials.Interface.EventArg;

namespace PokemonEssentials.Interface.Screen
{
	public interface IMysteryGiftData {
		int id				{ get; }
		/// <summary>
		/// 0=Pokémon; 1 or higher=item (is the item's quantity).
		/// </summary>
		/// ToDo: bool, or enum?
		int type			{ get; }
		Items item			{ get; }
		Pokemons species	{ get; }
		string giftname		{ get; }
	}

	public interface ITrainerMysteryGift {
		/// <summary>
		/// Whether <see cref="IGameMysteryGift"/> can be used from load screen
		/// </summary>
		bool mysterygiftaccess				{ get; set; }
		/// <summary>
		/// Variable that stores downloaded <see cref="IGameMysteryGift"/> data
		/// </summary>
		IMysteryGiftData mysterygift		{ get; set; }

		//bool mysterygiftaccess() {
		//	if (!@mysterygiftaccess) @mysterygiftaccess=false;
		//	return @mysterygiftaccess;
		//}

		//byte[] mysterygift() {
		//	if (!@mysterygift) @mysterygift=[];
		//	return @mysterygift;
		//}
	}

	/// <summary>
	/// Extension of <see cref="IGame"/>
	/// </summary>
	public interface IGameMysteryGift
	{
		/// <summary>
		/// This url is the location of an example Mystery Gift file.
		/// </summary>
		/// <remarks>
		/// You should change it to your file's url once you upload it.
		/// </remarks>
		/// Mystery Gift system
		/// By Maruno
		string MYSTERYGIFTURL { get; } //= "http://images1.wikia.nocookie.net/pokemonessentials/images/e/e7/MysteryGift.txt"


		/// <summary>
		/// Creating a new Mystery Gift for the Master file, and editing an existing one.
		///
		/// </summary>
		/// <param name="type">0=Pokémon; 1 or higher=item (is the item's quantity).</param>
		/// <param name="item">The thing being turned into a Mystery Gift (Pokémon object or item ID).</param>
		/// <param name="id"></param>
		/// <param name="giftname"></param>
		/// <returns></returns>
		//IMysteryGiftData EditMysteryGift(int type, Items item, int id = 0, string giftname = "");
		IMysteryGiftData EditMysteryGift(Items item, int id = 0, string giftname = "");
		IMysteryGiftData EditMysteryGift(Pokemons pkmn, int id = 0, string giftname = "");

		//void CreateMysteryGift(int type, Items item);
		void CreateMysteryGift(Items item);
		void CreateMysteryGift(Pokemons pkmn);



		// ###############################################################################
		// Debug option for managing gifts in the Master file and exporting them to a
		// file to be uploaded.
		// ###############################################################################
		void ManageMysteryGifts();

		void RefreshMGCommands(IMysteryGiftData[] master, int[] online);



		// ###############################################################################
		// Downloads all available Mystery Gifts that haven't been downloaded yet.
		// ###############################################################################
		// Called from the Continue/New Game screen.
		ITrainer DownloadMysteryGift(ITrainer trainer);



		// ###############################################################################
		// Converts an array of gifts into a string and back.
		// ###############################################################################
		string MysteryGiftEncrypt(IMysteryGiftData gift);

		IMysteryGiftData MysteryGiftDecrypt(string gift);



		// ###############################################################################
		// Collecting a Mystery Gift from the deliveryman.
		// ###############################################################################
		int NextMysteryGiftID();

		bool ReceiveMysteryGift(int id);
	}
}