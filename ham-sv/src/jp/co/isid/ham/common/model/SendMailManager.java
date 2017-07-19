package jp.co.isid.ham.common.model;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.HAMLogUtility;


public class SendMailManager {

    /** �V���O���g���C���X�^���X */
    private static SendMailManager _manager = new SendMailManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private SendMailManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static SendMailManager getInstance() {
        return _manager;
    }

    /**
     * ���[�����M
     * @param vo ���[�����M�f�[�^
     * @throws HAMException
     */
    public void sendMail(SendMailVO vo) throws HAMException {

        MailTransport tp = null;

        try {
            tp = new MailTransport(vo.getEsqId(), vo.getPassword(), true);
            //���M�T�[�o�[�ɐڑ�.
            HAMLogUtility.debug("���������M�T�[�o�[�ɐڑ�������");
            tp.connect();
            ////// ���M�҃��[���A�h���X�̐ݒ�
            HAMLogUtility.debug("���������M�҃��[���A�h���X�̐ݒ聥����");
            tp.setSenderAddress(vo.getFromAddress());
            HAMLogUtility.debug("���������M�҃C���^�[�l�b�g���̐ݒ聥����");
            ////// ���M�҃C���^�[�l�b�g���̐ݒ�
            tp.setSenderName(vo.getFromName());

            for (int i = 0; i < vo.getSendMailInfo().size(); i++) {
                HAMLogUtility.debug("���������[�����̐ݒ聥����" + (i + 1));
                SendMailInfoVO mailInfo = vo.getSendMailInfo().get(i);

                ////// �����̐ݒ�
                tp.setSubject(mailInfo.getSubject());
                ////// �{���̐ݒ�
                tp.setMessage(mailInfo.getBody());

                tp.clearRecipientList();
                ////// ����(To)���̕ҏW
                if (mailInfo.getToAddress() != null && mailInfo.getToName() != null) {
                    for (int j = 0; j < mailInfo.getToAddress().size(); j++) {
                        tp.addRecipientTo(mailInfo.getToAddress().get(j), mailInfo.getToName().get(j));
                    }
                }
                ////// ����(Cc)���̕ҏW
                if (mailInfo.getCcAddress() != null && mailInfo.getCcName() != null) {
                    for (int j = 0; j < mailInfo.getCcAddress().size(); j++) {
                        tp.addRecipientCc(mailInfo.getCcAddress().get(j), mailInfo.getCcName().get(j));
                    }
                }
                ////// ����(Bcc)���̕ҏW
                if (mailInfo.getBccAddress() != null && mailInfo.getBccName() != null) {
                    for (int j = 0; j < mailInfo.getBccAddress().size(); j++) {
                        tp.addRecipientBcc(mailInfo.getBccAddress().get(j), mailInfo.getBccName().get(j));
                    }
                }

//                tp.setHighPriority();
//                tp.setKaifuFlg(true);

                ////// ���b�Z�[�W�̑��M
                tp.send();
            }
        } catch(Exception ex) {
            HAMLogUtility.debug("���������[�����M���G���[�����F������");
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
                    HAMLogUtility.debug("���������M�T�[�o�[��ؒf������");
                    //���M�T�[�o�[��ؒf.
                    tp.terminate();
                }
            } catch(Exception ex2) {
                throw new HAMException(ex2.getCause());
            }
        }
    }

}
