﻿using EcommerceBasicoAWS.Data;
using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBasicoAWS.Repositories
{
    public class CarritoRepository : ICarritoRepository
    {

        private readonly ApplicationDbContext _context;

        public CarritoRepository(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<bool> AddItemCarrito(Carrito carrito, ItemCarrito itemCarrito)
        {
            try
            {
                if (carrito.ItemsCarrito == null) { 
                    carrito.ItemsCarrito = new List<ItemCarrito>();
                }
                carrito.ItemsCarrito.Add(itemCarrito);
                carrito.Total += itemCarrito.Subtotal;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public async Task<bool> ClearCarritoItems(string userId)
        {
            bool response = false;
            Carrito? carrito = await GetUserCarrito(userId);
            if (carrito != null) {
                carrito.ItemsCarrito.Clear();
                carrito.Total = 0;
                _context.SaveChanges();
                response = true;
            }

            return response;
        }

        public async Task<Carrito> CreateCarrito(Carrito carrito)
        {
            await _context.Carritos.AddAsync(carrito);
            _context.SaveChanges();

            return carrito;
        }

        public async Task<bool> DeleteUserCarrito(string userId)
        {
            Carrito? carrito = await GetUserCarrito(userId);
            bool response = false;
            if (carrito != null) {
                _context.Carritos.Remove(carrito);
                _context.SaveChanges();
                response = true;
            }

            return response;
        }

        public async Task<ItemCarrito?> GetItemCarrito(string userId, Guid idItemCarrito)
        {
            Carrito? carrito = await GetUserCarrito(userId);
            ItemCarrito? itemcarrito = null;
            if(carrito != null)
            {
                itemcarrito = carrito.ItemsCarrito.SingleOrDefault(i => i.IdItemCarrito == idItemCarrito);
            }

            return itemcarrito;
        }

        public async Task<Carrito?> GetUserCarrito(string userId)
        {
            Carrito? carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.IdUsuario == userId);

            return carrito;
        }

        public async Task<bool> RemoveItemCarrito(string userId, Guid idItemCarrito)
        {
            Carrito? carrito = await GetUserCarrito(userId);
            bool response = false;
            if(carrito != null)
            {
                ItemCarrito? itemCarrito = carrito.ItemsCarrito.SingleOrDefault(i => i.IdItemCarrito == idItemCarrito);

                if (itemCarrito != null) {
                    carrito.ItemsCarrito.Remove(itemCarrito);
                    carrito.Total -= itemCarrito.Subtotal;
                    _context.SaveChanges();
                    response = true;
                }
            }

            return response;
        }
    }
}
