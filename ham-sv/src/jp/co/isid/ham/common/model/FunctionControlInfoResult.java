package jp.co.isid.ham.common.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �@�\������Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/11 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FunctionControlInfoResult extends AbstractServiceResult
{
    /** �@�\������VO���X�g */
    private List<FunctionControlInfoVO> _functionControlInfoVO;

    /**
     * �@�\������VO���X�g���擾���܂�
     * @return �@�\������VO���X�g
     */
    public List<FunctionControlInfoVO> getFunctionControlInfo()
    {
        return _functionControlInfoVO;
    }

    /**
     * �@�\������VO���X�g��ݒ肵�܂�
     * @param securityInfoVO �@�\������VO���X�g
     */
    public void setFunctionControlInfo(List<FunctionControlInfoVO> functionControlInfoVO)
    {
        _functionControlInfoVO = functionControlInfoVO;
    }


    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy()
    {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy)
    {
        this._dummy = dummy;
    }

}
