using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BuildingGame
{
    class Map
    {
        int width;
        int height;
        int cellWidth;
        int cellHeight;

        byte rotation;

        Grid grid;


        List<Building> buildingObjects;
        List<NatureObject> natureObjects;

        Inventory inventory;
        Camera camera;

        SpriteBatch sp;

        public Map(int Width, int Height)
        {
            width = Width;
            height = Height;
            cellWidth = 64; //TODO Change static tilesize
            cellHeight = 32; //TODO Change static tilesize
            rotation = 0;
            grid = new Grid(width, height, cellWidth, cellHeight);
            buildingObjects = new List<Building>();
            natureObjects = new List<NatureObject>();



            inventory = new Inventory();

            

            CreateTerrain();

        }

        internal void AddObject(MapObject mapObject)
        {
            if (mapObject is Building)
            {
                Building b = (Building)mapObject;
                buildingObjects.Add(b);
                foreach (Cell c in mapObject.Cells)
                {
                    c.Building = b;
                }
            }
            if (mapObject is Tree)
            {
                Tree t = (Tree)mapObject;
                natureObjects.Add(t);
                foreach (Cell c in mapObject.Cells)
                {
                    c.Tree = t;
                }
            }

        }

        private void CreateTerrain()
        {
            Random r = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid.GetCell(x, y).Sprite = Sprites.Gras;
                    //if (r.Next(5) == 1)
                    //{
                    //    Tree t = new Tree();
                    //    t.Cells[0, 0] = grid.Cells[x, y];
                    //    AddObject(t);
                    //}
                }
            }
        }

        
        public void Update(GameTime gameTime)
        {
            float tick = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                rotation = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F2))
            {
                rotation = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F3))
            {
                rotation = 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                rotation = 3;
            }

            camera.Update(tick);


            foreach (Building b in buildingObjects)
            {
                b.Update(tick);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            float tick = (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetMatrix());
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (rotation == 0)
                    {
                        grid.GetCell(width-1 - x, height-1 - y).Draw(spriteBatch, this);
                    }
                    else if (rotation == 1)
                    {
                        grid.GetCell(x, height-1 - y).Draw(spriteBatch, this);
                    }
                    else if (rotation == 2)
                    {
                        grid.GetCell(x, y).Draw(spriteBatch, this);
                    }
                    else if (rotation == 3)
                    {
                        grid.GetCell(width-1 - x, y).Draw(spriteBatch, this);
                    }
                }
            }
            spriteBatch.End();
        }


        public Vector2 CalcWorldToScreen(Vector2 worldPosition)
        {
            float x = 0;
            float y = 0;
            float a = worldPosition.X;
            float b = worldPosition.Y;
            float c = cellWidth;
            float d = cellHeight;

            if (rotation == 0)
            {
                x = 0.5f * (b * c - a * c);
                y = 0.5f * (-a * d - b * d);
            }
            else if (rotation == 1)
            {
                x = 0.5f * (-a * c - b * c);
                y = 0.5f * (a * d - b * d);
            }
            else if (rotation == 2)
            {
                x = 0.5f * (a * c - b * c);
                y = 0.5f * (a * d + b * d);
            }
            else if (rotation == 3)
            {
                x = 0.5f * (a * c + b * c);
                y = 0.5f * (b * d - a * d);
            }

            return (new Vector2(x, y));
        }

        public Vector2 CalcScreenToWorld(Vector2 screenPosition)
        {
            float x = screenPosition.X;
            float y = screenPosition.Y;
            float a = 0;
            float b = 0;
            float c = cellWidth;
            float d = cellHeight;

            if (rotation == 0)
            {
                a = -x / c - y / d;
                b = x / c - y / d;
            }
            else if (rotation == 1)
            {
                a = y / d - x / c;
                b = -x / c - y / d;
            }
            else if (rotation == 2)
            {
                a = x / c + y / d;
                b = y / d - x / c;
            }
            else if (rotation == 3)
            {
                a = x / c - y / d;
                b = x / c + y / d;
            }

            return (new Vector2(a, b));
        }


        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public byte Rotation
        {
            get
            {
                return rotation;
            }
        }

        public Grid Grid
        {
            get
            {
                return grid;
            }
        }

        public Camera Camera
        {
            get
            {
                return camera;
            }
            set
            {
                camera = value;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
        }

        public List<Building> Buildings
        {
            get
            {
                return buildingObjects;
            }
        }
    }
}