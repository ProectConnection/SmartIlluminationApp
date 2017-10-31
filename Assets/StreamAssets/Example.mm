//
//  Example.m
//  NP_Unity
//
//  Created by yukio.miyamoto on 2017/10/13.
//  Copyright © 2017年 Yukio Miyamoto. All rights reserved.
//

#import <Foundation/Foundation.h>
//#import "UnitySwift-Bridging-Header.h"
#import "SmartIlluminationApp-Swift.h"

extern "C"{
    void _ex_callSwiftMethod(const char *CMPedmeter){
//        [Example swiftMethod:[NSString stringWithUTF8String:CMPedmeter]];
        [Example swiftMethodWith_CMPedometer:[NSString stringWithUTF8String:CMPedmeter]];
    }
}
