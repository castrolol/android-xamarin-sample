using System;
using Android.Widget;
using Java.Util.Streams;
using Java.Util;
using Android.Content;
using System.Collections.Generic;

namespace PessoaManager.Droid
{
   /* public class PessoaArrayAdapter : ArrayAdapter<User>
    {
        public PessoaArrayAdapter(Context context, List<Pessoa> pessoas) : base(context, Android.Resource.Layout.SimpleListItem2, Android.Resource.Id.Text1, pessoas)
        {
        }


        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            var view = base.GetView(position, convertView, parent);
            var item = GetItem(position);

            var text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            text1.Text = item.Nome;
            text2.Text = item.Cargo;


            return view;
        
        
        }



    } */
}
