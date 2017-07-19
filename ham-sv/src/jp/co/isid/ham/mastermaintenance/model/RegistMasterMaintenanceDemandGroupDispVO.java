package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ������O���[�v�\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceDemandGroupDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ������O���[�v�o�^�f�[�^VO */
    private RegistMbj26BillGroupVO _demandGroupVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceDemandGroupDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceDemandGroupDispVO();
    }

    /**
     * ������O���[�v�o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _demandGroupVO
     */
    public void setDemandGroupVO(RegistMbj26BillGroupVO vo)
    {
        _demandGroupVO = vo;
    }

    /**
     * ������O���[�v�o�^�f�[�^VO���擾���܂�
     * @return _demandGroupVO
     */
    public RegistMbj26BillGroupVO getDemandGroupVO()
    {
        return _demandGroupVO;
    }

}
