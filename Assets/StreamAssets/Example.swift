//
//  Example.swift
//  NP_Unity
//
//  Created by yukio.miyamoto on 2017/10/12.
//  Copyright © 2017年 Yukio Miyamoto. All rights reserved.
//

import Foundation



class Example: _CMPedometer {
    static func swiftMethod(_CMPedometer: String){
        //UnitySendMessage("CallbackTarget","OnCallFromSwift","Hello,Unity!")
        @IBOutlet var CMPSteepe:CMPedometer!
        
        // class wide constant !!
        let pedometer = CMPedometer()
        
        override func viewDidLoad() {
            super.viewDidLoad()
            // Do any additional setup after loading the view, typically from a nib.
            
            // CMPedometerの確認
            if(CMPedometer.isStepCountingAvailable()){
                
                self.pedometer.startUpdates(from: NSDate() as Date) {
                    (data: CMPedometerData?, error) -> Void in
                    DispatchQueue.main.async(execute: { () -> Void in
                        if(error == nil){
                            // 歩数
                            let steps = data!.numberOfSteps
                            self.CMPSteepe.text = "steps: \(steps)"
                        }
                    })
                }
            }
            
        
    }
}
