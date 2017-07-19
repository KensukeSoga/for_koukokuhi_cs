package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �����\���o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMasterMaintenanceDepartmentDispVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �����o�^�f�[�^VO */
    private RegistMbj32DepartmentVO _departmentVO = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMasterMaintenanceDepartmentDispVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMasterMaintenanceDepartmentDispVO();
    }

    /**
     * �����o�^�f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _departmentVO
     */
    public void setDepartmentVO(RegistMbj32DepartmentVO vo)
    {
        _departmentVO = vo;
    }

    /**
     * �����o�^�f�[�^VO���擾���܂�
     * @return _departmentVO
     */
    public RegistMbj32DepartmentVO getDepartmentVO()
    {
        return _departmentVO;
    }

}
