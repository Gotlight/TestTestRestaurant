using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    [Serializable]
    public class ModelOrganization
    {
        public string ID;
        public string OrganizationName;
        public string OrganizationTypeName;
        public string OrganizationLogo;
        public byte[] Logo;
        public Sprite GallerySprite;
        public MenuCatalogs Catalogs = new MenuCatalogs();
        public MenuItems Items = new MenuItems();
    }
}