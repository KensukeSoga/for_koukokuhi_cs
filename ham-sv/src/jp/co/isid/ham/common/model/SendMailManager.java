package jp.co.isid.ham.common.model;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.HAMLogUtility;


public class SendMailManager {

    /** シングルトンインスタンス */
    private static SendMailManager _manager = new SendMailManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private SendMailManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static SendMailManager getInstance() {
        return _manager;
    }

    /**
     * メール送信
     * @param vo メール送信データ
     * @throws HAMException
     */
    public void sendMail(SendMailVO vo) throws HAMException {

        MailTransport tp = null;

        try {
            tp = new MailTransport(vo.getEsqId(), vo.getPassword(), true);
            //送信サーバーに接続.
            HAMLogUtility.debug("▼▼▼送信サーバーに接続▼▼▼");
            tp.connect();
            ////// 送信者メールアドレスの設定
            HAMLogUtility.debug("▼▼▼送信者メールアドレスの設定▼▼▼");
            tp.setSenderAddress(vo.getFromAddress());
            HAMLogUtility.debug("▼▼▼送信者インターネット名の設定▼▼▼");
            ////// 送信者インターネット名の設定
            tp.setSenderName(vo.getFromName());

            for (int i = 0; i < vo.getSendMailInfo().size(); i++) {
                HAMLogUtility.debug("▼▼▼メール情報の設定▼▼▼" + (i + 1));
                SendMailInfoVO mailInfo = vo.getSendMailInfo().get(i);

                ////// 件名の設定
                tp.setSubject(mailInfo.getSubject());
                ////// 本文の設定
                tp.setMessage(mailInfo.getBody());

                tp.clearRecipientList();
                ////// 宛先(To)情報の編集
                if (mailInfo.getToAddress() != null && mailInfo.getToName() != null) {
                    for (int j = 0; j < mailInfo.getToAddress().size(); j++) {
                        tp.addRecipientTo(mailInfo.getToAddress().get(j), mailInfo.getToName().get(j));
                    }
                }
                ////// 宛先(Cc)情報の編集
                if (mailInfo.getCcAddress() != null && mailInfo.getCcName() != null) {
                    for (int j = 0; j < mailInfo.getCcAddress().size(); j++) {
                        tp.addRecipientCc(mailInfo.getCcAddress().get(j), mailInfo.getCcName().get(j));
                    }
                }
                ////// 宛先(Bcc)情報の編集
                if (mailInfo.getBccAddress() != null && mailInfo.getBccName() != null) {
                    for (int j = 0; j < mailInfo.getBccAddress().size(); j++) {
                        tp.addRecipientBcc(mailInfo.getBccAddress().get(j), mailInfo.getBccName().get(j));
                    }
                }

//                tp.setHighPriority();
//                tp.setKaifuFlg(true);

                ////// メッセージの送信
                tp.send();
            }
        } catch(Exception ex) {
            HAMLogUtility.debug("▼▼▼メール送信中エラー発生：▼▼▼");
            HAMLogUtility.debug(ex.getMessage());
            for (int i = 0; i < ex.getStackTrace().length; i++) {
                HAMLogUtility.debug(ex.getStackTrace()[i].toString());
            }
            HAMLogUtility.debug("==========================================================");
            ex.printStackTrace();
            throw new HAMException(ex.getCause());
        } finally {
            try {
                if (tp != null) {
                    HAMLogUtility.debug("▼▼▼送信サーバーを切断▼▼▼");
                    //送信サーバーを切断.
                    tp.terminate();
                }
            } catch(Exception ex2) {
                throw new HAMException(ex2.getCause());
            }
        }
    }

}
