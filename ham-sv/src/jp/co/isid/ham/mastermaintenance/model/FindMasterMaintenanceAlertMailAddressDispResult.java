package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ���[���z�M�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/07 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAlertMailAddressDispResult extends AbstractServiceResult
{
    /** ���[���z�M�����f�[�^VO */
    private FindMbj40AlertMailAddressVO _alartMailAddressVO = null;

    /** �R�[�h�}�X�^�����f�[�^VO */
    private FindMbj12CodeVO _codeVO = null;

    /**
     * ���[���z�M�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _alartMailAddressVO
     */
    public void setAlertMailAddressVO(FindMbj40AlertMailAddressVO vo)
    {
        _alartMailAddressVO = vo;
    }

    /**
     * ���[���z�M�����f�[�^VO���擾���܂�
     * @return _alartMailAddressVO
     */
    public FindMbj40AlertMailAddressVO getAlertMailAddressVO()
    {
        return _alartMailAddressVO;
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
