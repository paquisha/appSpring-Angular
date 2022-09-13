import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Product } from 'src/Model/Product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  ProductList ? : Observable < Product[] > ;
  ProductList1 ? : Observable < Product[] > ;
  productForm: any;
  productId = 0;

  constructor(private formbulider: FormBuilder, private productService: ProductsService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.productForm = this.formbulider.group({
        productName: ['', [Validators.required]],
        productPrice: ['', [Validators.required]],
        productDescription: ['', [Validators.required]],
        productStock: ['', [Validators.required]]
    });
    this.getProductList();
  }

  //lista todos los productos
  getProductList() {
    this.ProductList1 = this.productService.getProductList();
    this.ProductList = this.ProductList1;
  }

  //agrega producto
  PostProduct(product: Product) {
    const product_Master = this.productForm.value;
    this.productService.postProductData(product_Master).subscribe(
        () => {
            this.getProductList();
            this.productForm.reset();
            this.toastr.success('Data Saved Successfully');
        });
  }

  //edita producto
  ProductDetailsToEdit(id: string) {
    this.productService.getProductDetailsById(id).subscribe(productResult => {
        this.productId = productResult.productId;
        this.productForm.controls['productName'].setValue(productResult.productName);
        this.productForm.controls['productPrice'].setValue(productResult.productPrice);
        this.productForm.controls['productDescription'].setValue(productResult.productDescription);
        this.productForm.controls['productStock'].setValue(productResult.productStock);
    });
  }

  //actualiza producto
  UpdateProduct(product: Product) {
    product.productId = this.productId;
    const product_Master = this.productForm.value;
    this.productService.updateProduct(product_Master).subscribe(() => {
        this.toastr.success('Data Updated Successfully');
        this.productForm.reset();
        this.getProductList();
    });
  }
  
  //borra producto
  DeleteProduct(id: number) {
    if (confirm('Do you want to delete this product?')) {
        this.productService.deleteProductById(id).subscribe(() => {
            this.toastr.success('Data Deleted Successfully');
            this.getProductList();
        });
    }
  }

  //limpia la pantalla
  Clear(product: Product) {
    this.productForm.reset();
  }

}
