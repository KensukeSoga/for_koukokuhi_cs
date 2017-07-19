package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����@�N�����f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetIniDataForCheckListResult  extends AbstractServiceResult {

    /* =============================================================================================*/
//    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
//    private String _dummy;
//
//    /**
//     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
//     * @return String �_�~�[�v���p�e�B
//     */
//    public String getDummy() {
//        return _dummy;
//    }
//
//	/**
//	 * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
//	 * @param dummy �_�~�[�v���p�e�B
//	 */
//	public void setDummy(String dummy) {
//		this._dummy = dummy;
//	}
    /* =============================================================================================*/

    /** �R�[�h�}�X�^VO���X�g */
    private List<Mbj12CodeVO> _mbj12CodeVoList = null;

    /** �o���g�D�W�J�e�[�u��VO���X�g */
    private List<RepaVbjaMeu07SikKrSprdVO> _meu07SikKrSprdVoList = null;

    /** �������VO���X�g */
    private List<CheckListThsDataVO> _checkListThsDataVoList = null;

    /**
     * �R�[�h�}�X�^VO���X�g���擾����
     * @return �R�[�h�}�X�^VO���X�g
     */
    public List<Mbj12CodeVO> getMbj12CodeVoList() {
        return _mbj12CodeVoList;
    }

    /**
     * �R�[�h�}�X�^VO���X�g��ݒ肷��
     * @param mbj12CodeVoList �R�[�h�}�X�^VO���X�g
     */
    public void setMbj12CodeVoList(List<Mbj12CodeVO> mbj12CodeVoList) {
        this._mbj12CodeVoList = mbj12CodeVoList;
    }

    /**
     * �o���g�D�W�J�e�[�u��VO���X�g���擾����
     * @return �R�[�h�}�X�^VO���X�g
     */
    public List<RepaVbjaMeu07SikKrSprdVO> getMeu07SikKrSprdVoList() {
        return _meu07SikKrSprdVoList;
    }

    /**
     * �o���g�D�W�J�e�[�u��VO���X�g��ݒ肷��
     * @param meu07SikKrSprdVoList �o���g�D�W�J�e�[�u��VO���X�g
     */
    public void setMeu07SikKrSprdVoList(List<RepaVbjaMeu07SikKrSprdVO> meu07SikKrSprdVoList) {
        this._meu07SikKrSprdVoList = meu07SikKrSprdVoList;
    }

    /**
     * �������VO���X�g���擾����
     * @return �������VO���X�g
     */
    public List<CheckListThsDataVO> getCheckListThsDataVoList() {
        return _checkListThsDataVoList;
    }

    /**
     * �������VO���X�g��ݒ肷��
     * @param checkListThsDataVoList �������VO���X�g
     */
    public void setCheckListThsDataVoList(List<CheckListThsDataVO> checkListThsDataVoList) {
        this._checkListThsDataVoList = checkListThsDataVoList;
    }

}
