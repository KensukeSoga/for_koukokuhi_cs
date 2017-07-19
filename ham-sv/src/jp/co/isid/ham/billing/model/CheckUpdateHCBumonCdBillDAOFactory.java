package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * ������Gr�R�[�h�X�V�`�F�b�N�pDAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/04/20 K.Soga)<BR>
 * </P>
 * @author K.Soga
 */
public class CheckUpdateHCBumonCdBillDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private CheckUpdateHCBumonCdBillDAOFactory() {
    }

    /**
     * ������Gr�R�[�h�X�V�`�F�b�N�pDAO�C���X�^���X�𐶐����܂�
     *
     * @return ������Gr�R�[�h�X�V�`�F�b�N�pDAO�C���X�^���X
     */
    public static CheckUpdateHCBumonCdBillDAO createCheckUpdateHCBumonCdBillDAO() {
        return new CheckUpdateHCBumonCdBillDAO();
    }

}
