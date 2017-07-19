package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �����\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceDepartmentDispResult extends AbstractServiceResult
{
    /** ���������f�[�^VO */
    private FindMbj32DepartmentVO _departmentVO = null;

    /** �R�[�h�}�X�^�����f�[�^VO */
    private FindMbj12CodeVO _codeVO = null;

    /**
     * ���������f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _departmentVO
     */
    public void setDepartmentVO(FindMbj32DepartmentVO vo)
    {
        _departmentVO = vo;
    }

    /**
     * ���������f�[�^VO���擾���܂�
     * @return _departmentVO
     */
    public FindMbj32DepartmentVO getDepartmentVO()
    {
        return _departmentVO;
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _codeVO
     */
    public void setCodeVO(FindMbj12CodeVO vo)
    {
        _codeVO = vo;
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO���擾���܂�
     * @return _codeVO
     */
    public FindMbj12CodeVO getCodeVO()
    {
        return _codeVO;
    }

}
