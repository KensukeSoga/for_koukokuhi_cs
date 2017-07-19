package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * CR�����Ǘ�(�����ݒ�p)DAO�̃t�@�N�g���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCrCreateDataForCmsDAOFactory extends DaoFactory {

    /**
     * �C���X�^���X�����֎~
     */
    private FindCrCreateDataForCmsDAOFactory() {
    }

    /**
     * CR�����Ǘ�(�����ݒ�p)DAO�̃C���X�^���X�𐶐����܂�
     *
     * @return CR�����Ǘ�(�����ݒ�p)DAO
     */
    public static FindCrCreateDataForCmsDAO createFindCrCreateDataForCmsDAO() {
        return new FindCrCreateDataForCmsDAO();
    }
}
