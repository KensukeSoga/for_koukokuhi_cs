package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ��p���No�\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceCostPlanDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ��p���No�o�^�f�[�^VO */
    private RegistMbj09HiyouVO _costPlanVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceCostPlanDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceCostPlanDispVO();
    }

    /**
     * ��p���No�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _costPlanVO
     */
    public void setCostPlanVO(RegistMbj09HiyouVO vo)
    {
        _costPlanVO = vo;
    }

    /**
     * ��p���No�o�^�f�[�^VO���擾���܂�
     * @return _costPlanVO
     */
    public RegistMbj09HiyouVO getCostPlanVO()
    {
        return _costPlanVO;
    }

}
