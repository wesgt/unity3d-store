/*
 * Copyright (C) 2012 Soomla Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using UnityEngine;
using System.Collections;

namespace com.soomla.unity{	

/**
 * Every game has its virtualCurrencies. Here you represent a pack of a specific VirtualCurrency.
 * For example: If you have a "Coin" as a virtual currency, you will
 * sell packs of "Coins". e.g. "10 Coins Set" or "Super Saver Pack".
 *
 * This VirtualItem is purchasable.
 * In case you purchase this item in Google Play (PurchaseWithMarket), You need to define the google item in Google
 * Play Developer Console. (https://play.google.com/apps/publish)
 */
	/// <summary>
	/// Every game has its virtualCurrencies. Here you represent a pack of a specific VirtualCurrency.
 	/// For example: If you have a "Coin" as a virtual currency, you will
 	/// sell packs of "Coins". e.g. "10 Coins Set" or "Super Saver Pack".
	///
 	/// This VirtualItem is purchasable.
 	/// In case you purchase this item in Google Play or the App Store(PurchaseWithMarket), You need to define the item in Google
 	/// Play Developer Console or in iTunesConnect. (https://play.google.com/apps/publish) (https://itunesconnect.apple.com)
	/// </summary>
	public class VirtualCurrencyPack : PurchasableVirtualItem {
//		private static string TAG = "SOOMLA VirtualCurrencyPack";
		
		public int CurrencyAmount;
		public string CurrencyItemId;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="com.soomla.unity.VirtualCurrencyPack"/> class.
		/// </summary>
		/// <param name='name'>
		/// see parent
		/// </param>
		/// <param name='description'>
		/// see parent
		/// </param>
		/// <param name='itemId'>
		/// see parent
		/// </param>
		/// <param name='currencyAmount'>
		/// The amount of currency in the pack.
		/// </param>
		/// <param name='currencyItemId'>
		/// The itemId of the currency associated with this pack.
		/// </param>
		/// <param name='purchaseType'>
		/// see parent
		/// </param>
		public VirtualCurrencyPack(string name, string description, string itemId, int currencyAmount, string currencyItemId, PurchaseType purchaseType)
			: base(name, description, itemId, purchaseType)
		{
			this.CurrencyAmount = currencyAmount;
			this.CurrencyItemId = currencyItemId;
		}
		
#if UNITY_ANDROID
		public VirtualCurrencyPack(AndroidJavaObject jniVirtualCurrencyPack) 
			: base(jniVirtualCurrencyPack)
		{
			this.CurrencyAmount = jniVirtualCurrencyPack.Call<int>("getCurrencyAmount");

			// Virtual Currency
			CurrencyItemId = jniVirtualCurrencyPack.Call<string>("getCurrencyItemId");
		}
#endif
		/// <summary>
		/// see parent
		/// </summary>
		public VirtualCurrencyPack(JSONObject jsonItem)
			: base(jsonItem)
		{
			this.CurrencyAmount = System.Convert.ToInt32(((JSONObject)jsonItem[JSONConsts.CURRENCYPACK_CURRENCYAMOUNT]).n);
			
			CurrencyItemId = jsonItem[JSONConsts.CURRENCYPACK_CURRENCYITEMID].str;
		}
		
		/// <summary>
		/// see parent
		/// </summary>
		public override JSONObject toJSONObject() {
			JSONObject obj = base.toJSONObject();
			obj.AddField(JSONConsts.CURRENCYPACK_CURRENCYAMOUNT, this.CurrencyAmount);
			obj.AddField(JSONConsts.CURRENCYPACK_CURRENCYITEMID, this.CurrencyItemId);
			return obj;
		}

	}
}