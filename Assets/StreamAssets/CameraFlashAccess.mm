//
//  CameraFlashAccess.m
//  CameraFlash_native
//
//  Created by yukio.miyamoto on 2017/12/01.
//  Copyright © 2017年 Yukio Miyamoto. All rights reserved.



#import <Foundation/Foundation.h>
#import <AssetsLibrary/AssetsLibrary.h>
#import <AVFoundation/AVFoundation.h>

//WriteImageToAlbum(SHKフォトアルバムのクラス)
extern "C" void _WriteImageToCamera(const char* path,char* CalledGameObjectName,char* CalledMethodName){
    AVCaptureDevice *captureDevice = [AVCaptureDevice defaultDeviceWithMediaType:AVMediaTypeVideo];
    
    
    if (captureDevice.torchMode == AVCaptureTorchModeOn){
//        self.view.backgroundColor = [UIButton whiteColor];
        NSLog(@"ンゴ");
        [captureDevice lockForConfiguration:NULL];
        captureDevice.torchMode = AVCaptureTorchModeOff;
        [captureDevice unlockForConfiguration];
        
    }else{
//        self.view.backgroundColor = [UIColor blackColor];
        
        [captureDevice lockForConfiguration:NULL];
        captureDevice.torchMode = AVCaptureTorchModeOn;
        [captureDevice unlockForConfiguration];
        
    }
    
}
/*
extern "C" void {
    void ngogo(){
        NSLog(@"N/Go");
        
    }
    
}
*/

