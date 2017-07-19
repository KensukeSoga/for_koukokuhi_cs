package jp.co.isid.ham.billing.model;

import jp.co.isid.nj.integ.DaoFactory;

/**
 * <P>
 * JJASRAC�������׏�(���W�I�^�C��)����DAOFactory
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/19 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeBillDAOFactory extends DaoFactory{

    /**
     * �C���X�^���X�����֎~
     */
    private FindJasracRadioTimeBillDAOFactory() {
    }

    /**
     * JASRAC�\����(���W�I�^�C��)����DAO�C���X�^���X�𐶐����܂�
     * @return JASRAC�\����(���W�I�^�C��)����DAO�C���X�^���X
     */
    public static FindJasracRadioTimeBillDAO createFindJasracRadioTimeBillDao() {
        return new FindJasracRadioTimeBillDAO();
    }

}
