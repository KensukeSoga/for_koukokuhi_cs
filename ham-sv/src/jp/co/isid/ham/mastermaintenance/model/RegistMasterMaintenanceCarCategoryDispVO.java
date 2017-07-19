package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ԏ�J�e�S���\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCarCategoryDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �Ԏ�J�e�S���o�^�f�[�^VO */
    private RegistMbj20CarCategoryVO _carCategoryVO = null;

    /** �Ԏ�J�e�S���R�t�o�^�f�[�^VO */
    private RegistMbj22CategoryContentVO _carCategoryContentVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceCarCategoryDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCarCategoryDispVO();
    }

    /**
     * �Ԏ�J�e�S���o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carCategoryVO
     */
    public void setCarCategoryVO(RegistMbj20CarCategoryVO vo)
    {
        _carCategoryVO = vo;
    }

    /**
     * �Ԏ�J�e�S���o�^�f�[�^VO���擾���܂�
     * @return _carCategoryVO
     */
    public RegistMbj20CarCategoryVO getCarCategoryVO()
    {
        return _carCategoryVO;
    }

    /**
     * �Ԏ�J�e�S���R�t�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carCategoryContentVO
     */
    public void setCarCategoryContentVO(RegistMbj22CategoryContentVO vo)
    {
        _carCategoryContentVO = vo;
    }

    /**
     * �Ԏ�J�e�S���R�t�o�^�f�[�^VO���擾���܂�
     * @return _carCategoryContentVO
     */
    public RegistMbj22CategoryContentVO getCarCategoryContentVO()
    {
        return _carCategoryContentVO;
    }

}
